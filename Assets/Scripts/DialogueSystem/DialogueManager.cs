using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    // npc dialogue we are currently stepping through
    private DialogueSO currentConversation;
    private int stepNum;
    private bool dialogueActivated;

    // ui references
    private GameObject dialogueUI;
    private TMP_Text actor;
    private Image portrait;
    private TMP_Text dialogueText;

    private string currentSpeaker;
    private Sprite currentPortrait;

    public ActorSO[] actorSO;

    // button references
    private GameObject[] optionButton;
    private TMP_Text[] optionButtonText;
    private GameObject optionsPanel;

    //typewriter effect
    [SerializeField] private float typingSpeed = 0.02f;
    private Coroutine typewriterRoutine;
    private bool canContinueText = true;

    // player freeze
    private PlayerMovement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        //find player movement script
        playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();

        // find buttons
        optionButton = GameObject.FindGameObjectsWithTag("OptionButton");
        optionsPanel = GameObject.Find("OptionsPanel");
        optionsPanel.SetActive(false);

        // find the tmp text on the buttons
        optionButtonText = new TMP_Text[optionButton.Length];
        for (int i = 0; i < optionButton.Length; i++){
            optionButtonText[i] = optionButton[i].GetComponentInChildren<TMP_Text>();
        }

        // turn off buttons at start
        for (int i = 0; i < optionButton.Length; i++){
            optionButton[i].SetActive(false);
        }

        dialogueUI = GameObject.Find("DialogueUI");  
        actor = GameObject.Find("ActorText").GetComponent<TMP_Text>(); 
        portrait = GameObject.Find("Portrait").GetComponent<Image>();
        dialogueText = GameObject.Find("DialogueText").GetComponent<TMP_Text>();

        dialogueUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueActivated && Input.GetButtonDown("Interact") && canContinueText) {
            // freeze the player
            playerMove.enabled = false;

            // cancel dialogue if there are no more lines of dialogue
            if (stepNum >= currentConversation.actors.Length) {
                CompletedDialogue();
                // TurnOffDialogue();
            } else {
                //  continue dialogue
                PlayDialogue();
            }
        }
    }

    void PlayDialogue() {
        // if its a random npc
        if (currentConversation.actors[stepNum] == DialogueActors.Random) {
            SetActorInfo(false);
        } else {
             // if its a recurring character
            SetActorInfo(true);
        }

        // display dialogue   
        actor.text = currentSpeaker;
        portrait.sprite = currentPortrait;

        //if there is a branch
        if (currentConversation.actors[stepNum] == DialogueActors.Branch) {
            for (int i = 0; i < currentConversation.optionText.Length; i++){
                if (currentConversation.optionText[i] == null) {
                    // there are no options
                    optionButton[i].SetActive(false);
                } else {
                    // turns on the buttons we want only
                    optionButtonText[i].text = currentConversation.optionText[i];
                    optionButton[i].SetActive(true);
                } 

                // set the first button to be auto-selected
                optionButton[0].GetComponent<Button>().Select();
            }
        }

        // keep the routine from running multiple times at the same time
        if (typewriterRoutine != null) {
            StopCoroutine(typewriterRoutine);
        }

        if (stepNum < currentConversation.dialogue.Length) {
            typewriterRoutine = StartCoroutine(TypewriterEffect(dialogueText.text = currentConversation.dialogue[stepNum]));
        } else {
            optionsPanel.SetActive(true);
        }

        dialogueUI.SetActive(true);
        stepNum += 1;
    }

    void SetActorInfo(bool recurringCharacter) {
        if (recurringCharacter) {
            for (int i = 0; i < actorSO.Length; i++) {
                if (actorSO[i].name == currentConversation.actors[stepNum].ToString()){
                    currentSpeaker = actorSO[i].actorName;
                    currentPortrait = actorSO[i].actorPortrait;
                }
            }
        } else { 
            currentSpeaker = currentConversation.randomActorName;
            currentPortrait = currentConversation.randomActorPortrait;
        }
    }

    public void Option(int optionNum) {
        foreach (GameObject button in optionButton) {
            button.SetActive(false);
        }

        if (optionNum == 0) {
            currentConversation = currentConversation.option0;
        }
        if (optionNum == 1) {
            currentConversation = currentConversation.option1;
        }
        if (optionNum == 2) {
            currentConversation = currentConversation.option2;
        }
        if (optionNum == 3) {
            currentConversation = currentConversation.option3;
        }

        stepNum = 0;
        Debug.Log(stepNum + "selected option" + optionNum);
    }

    private IEnumerator TypewriterEffect(string line) {
        dialogueText.text = "";
        canContinueText = false;
        bool addingRichTextTag = false;
        yield return new WaitForSeconds(.3f);
        foreach (char letter in line.ToCharArray()) {
            if (Input.GetButtonDown("Interact")) {
                dialogueText.text = line;
                break;
            }

            //  check if we are using a rich text tag <> , we don't want to wait through the typing speed when going through the tags
            if (letter == '<' || addingRichTextTag) {
                addingRichTextTag = true;
                dialogueText.text += letter;
                if (letter == '>') {
                    addingRichTextTag = false;
                }
            } else {
               //  if not using rich text tags
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed); 
            }
        }
        canContinueText = true;
    }


    public void InitiateDialogue(NPCDialogue npcDialogue) {
        // the array we are currently stepping through
        currentConversation = npcDialogue.conversation[0];
        dialogueActivated = true;
    }

// when u leave trigger area - change this to work with finishing a convo too
    public void TurnOffDialogue() {
        stepNum = 0;
        dialogueActivated = false;
        optionsPanel.SetActive(false);
        dialogueUI.SetActive(false);  
        // unfreeze the player
        playerMove.enabled = true;
    }

    public void CompletedDialogue() {
        stepNum = 0;
        // left true bc you are still in the same trigger area, not sure why it doesn't still trigger but keep this function
        // if you talk to them again, the npc will say the last line they said (if time maybe reset the whole dialogue again but for now this)
        dialogueActivated = true;
        optionsPanel.SetActive(false);
        dialogueUI.SetActive(false);   
        // unfreeze the player
        playerMove.enabled = true;
    }

}

// we want this function to be global
// enum is a data type where we define them and make them available in a drop down menu
// all named chars go hear
public enum DialogueActors {
    Anthony,
    Theo,
    Random,
    Branch
};
