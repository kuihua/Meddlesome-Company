using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

public class DialogueManager : MonoBehaviour, ISelectHandler
{

    // npc dialogue we are currently stepping through
    private DialogueSO currentConversation;
    // variable for the original conversation in case of branching dialogue / restart at the top
    private DialogueSO originalConversation;
    private int stepNum;
    private bool dialogueActivated;
    // private bool dialogueCutsceneComplete;
    private bool isTriggerAreaDialogue; // for trigger dialogue areas

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

    // next arrow
    private GameObject nextArrow;

    //typewriter effect
    [SerializeField] private float typingSpeed = 0.02f;
    private Coroutine typewriterRoutine;
    private bool lineCompleted = true;
    private bool skipLine = false;

    // player freeze
    private PlayerMovement playerMove;

    // cutscene continuation
    private PlayableDirector playableDirector;
    private bool isCutscene = false;
    private bool isNPCExamine = false;

    // Start is called before the first frame update
    void Start()
    {
        //find player movement script
        playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();

        // get cutscene manager
        // cutscenePlayableManager = GameObject.Find("CutscenePlayableManager").GetComponent<CutscenePlayableManager>();

        // find buttons
        optionButton = GameObject.FindGameObjectsWithTag("OptionButton");
        // Debug.Log(optionButton[0].name + optionButton[1].name + optionButton[2].name + optionButton[3].name);
        optionsPanel = GameObject.Find("OptionsPanel");
        optionsPanel.SetActive(false);

        // next arrow
        nextArrow = GameObject.Find("NextArrow");
        nextArrow.SetActive(false);

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
        // show next arrow if line is complete
        if (dialogueActivated && lineCompleted) {
            nextArrow.SetActive(true);
        } else {
            nextArrow.SetActive(false);
        }

        if (dialogueActivated && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return)) && lineCompleted) {
            DialogueCheck();
        } 

        // skip the typewriter effect
        else if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) && !lineCompleted && dialogueActivated) {
            skipLine = true;
        }
    }

    // checks if there is still dialogue and plays it if there is
    void DialogueCheck() {
        // freeze the player
        // playerMove.rb.velocity = new Vector2(0, 0);
        playerMove.Stop();
        playerMove.enabled = false;

        // if there's no more lines, stop dialogue
        if (stepNum >= currentConversation.actors.Length) {
            nextArrow.SetActive(false);
            if(isTriggerAreaDialogue || isCutscene){
                TurnOffDialogue();
            } 
            else if(isNPCExamine) {
                // ExaminedDialogue();
                TurnOffDialogue();
            } 
            else {
                CompletedDialogue();
            }
        } 
        else {
            //  continue dialogue
            skipLine = false;
            PlayDialogue();
        }
    } // end of DialogueCheck()

    // function to set the portrait and name, sets options if there's a branch, plays the corresponding dialogue
    void PlayDialogue() {
        // if its a random npc
        if (currentConversation.actors[stepNum] == DialogueActors.Random) {
            SetActorInfo(false);
        } else {
             // if its a recurring character
            SetActorInfo(true);
        }

        // display name of speaker
        actor.text = currentSpeaker;

        // int index = currentSpeaker.LastIndexOf("_");
        // if (index >= 0) {
        //     Debug.Log("replaceing name with " + currentSpeaker.Substring(0, index));
        //     actor.text = currentSpeaker.Substring(0, index);
        // }
        
        // display speaker portrait
        portrait.sprite = currentPortrait;

        //if there is a branch display options
        if (currentConversation.actors[stepNum] == DialogueActors.Branch) {
            for (int i = 0; i < currentConversation.optionText.Length; i++){
                if (currentConversation.optionText[i] == null) {
                    // there are no options
                    optionButton[i].SetActive(false);
                } else {
                    // turns on the buttons we want only
                    optionButtonText[i].text = currentConversation.optionText[i];
                    // Debug.Log(optionButtonText[i].text + "" + optionButton[i].name);

                    optionButton[i].SetActive(true);
                } 

                // set the first button to be auto-selected
                optionButton[0].GetComponent<Button>().Select();
                // nextArrow.SetActive(false);
            }
        }

        // keep the routine from running multiple times at the same time
        if (typewriterRoutine != null) {
            StopCoroutine(typewriterRoutine);
        }

        // start the typewriter effect 
        if (stepNum < currentConversation.dialogue.Length) {
            // Debug.Log("started typing");
            typewriterRoutine = StartCoroutine(TypewriterEffect(dialogueText.text = currentConversation.dialogue[stepNum]));
        } else {
            optionsPanel.SetActive(true);
        }

        dialogueUI.SetActive(true);
        // increment stepNum to go to next line of dialogue
        stepNum += 1;
    }

    void SetActorInfo(bool recurringCharacter) {
        if (recurringCharacter) {
            for (int i = 0; i < actorSO.Length; i++) {
                if (actorSO[i].name == currentConversation.actors[stepNum].ToString()){
                    // getting name and portrait of ActorSO scriptable object
                    currentSpeaker = actorSO[i].actorName;
                    currentPortrait = actorSO[i].actorPortrait;
                }
            }
        } else { 
            currentSpeaker = currentConversation.randomActorName;
            currentPortrait = currentConversation.randomActorPortrait;
        }
    }

    // function to set the corresponding conversation after picking a conversation option
    public void Option(int optionNum) {
        foreach (GameObject button in optionButton) {
            button.SetActive(false);
        }

        // Debug.Log(currentConversation.option0.name + " is option " + optionNum);
        // Debug.Log(currentConversation.option1.name + " is option " + optionNum);
        // Debug.Log(currentConversation.option2.name + " is option " + optionNum);
        // Debug.Log(currentConversation.option3.name + " is option " + optionNum);

        // set conversation as the selected option conversation
        // the number is set in the inspector window
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

        stepNum = 0; // resets to 0 because we will be going into the next DialogueSO
        // Debug.Log(stepNum + "selected option" + optionNum);
    }

    private IEnumerator TypewriterEffect(string line) {
        dialogueText.text = "";
        lineCompleted = false;
        bool addingRichTextTag = false;
        // hide arrow so it won't show when dialogue first shows up
        nextArrow.SetActive(false);
        // yield return new WaitForSeconds(.5f);

        foreach (char letter in line.ToCharArray()) {

            // skips the typewriter effect for the line
            if (skipLine) {
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

        lineCompleted = true;
    }

    // setting the conversation as the npc's conversation (which gets set when player enters the trigger area)
    public void InitiateDialogue(NPCDialogue npcDialogue) {
        // save reference to the original conversation to set the current conversation back to when dialogue is completed
        originalConversation = npcDialogue.conversation[0];
        // the array we are currently stepping through
        currentConversation = npcDialogue.conversation[0];
        dialogueActivated = true;

        // if its a dialogue trigger area, play dialogue right away (no interaction needed)
        // also sets the trigger to true so it won't activate again if the player enters the same area again
        if (npcDialogue.GetIsTrigger()) {
            DialogueCheck();
            npcDialogue.SetIsTrigger(true);
            isTriggerAreaDialogue = true;
        }

        if (npcDialogue.GetIsNPCExamine()) {
            isNPCExamine = true;
            DialogueCheck();
        }

        // if it's part of the cutscene, we need to get reference to the SO because it can't get it on its own
        if(npcDialogue.GetIsCutscene()) {
            // pause timeline and assign variable, set speed instead of Pause() because it will reset animations
            playableDirector = npcDialogue.GetPlayableDirector();
            // Debug.Log(playableDirector.playableGraph.GetRootPlayable(0).GetSpeed());
            playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
            // playableDirector.Pause();
            isCutscene = true;
            // get conversation
            currentConversation = npcDialogue.GetDialogue()[0];
            DialogueCheck();
        }
    } // end of InitiateDialogue()

    // used for when player leaves the trigger area: reset variables, and set dialogue active to false
    public void TurnOffDialogue() {
        ResetDialogueVariables ();
        dialogueActivated = false;
        isTriggerAreaDialogue = false;
    }

    // used when player finishes a dialogue: reset variables, dialogue is still active (able to speak to the npc again)
    public void CompletedDialogue() {
        ResetDialogueVariables ();
        dialogueActivated = true;
    }

    // reset variables but keep player move disabled
    public void ExaminedDialogue(){
        skipLine = false;
        dialogueUI.SetActive(false);
        currentConversation = originalConversation;
        // set conversation step to 0 (from the top of the conversation)
        stepNum = 0;
        isNPCExamine = false;
        optionsPanel.SetActive(false);
    }

    private void ResetDialogueVariables () {
        skipLine = false;
        // unfreeze player (re enabling the player movement script)
        playerMove.enabled = true;
        // hide ui
        optionsPanel.SetActive(false);
        dialogueUI.SetActive(false);  
        // set the conversation to what it was initially (for the branching conversations, it would set the conversation to what it was prior before the branch)
        currentConversation = originalConversation;
        // set conversation step to 0 (from the top of the conversation)
        stepNum = 0;

        if (isCutscene) {
            // continue timeline
            playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
            // playableDirector.Resume();
            isCutscene = false;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
    }
}

// we want this function to be global
// enum is a data type where we define them and make them available in a drop down menu
// all named chars go hear
public enum DialogueActors {
    Anthony,
    Anthony_HappyL,
    Anthony_HappyR,
    Anthony_Angry,
    Anthony_Err,
    Anthony_Nervous,
    Anthony_Shock,
    Anthony_Shy,
    Anthony_Smug,
    Anthony_SneakHappy,
    Anthony_Upset,

    Theo,
    Theo_Happy,
    Theo_Angry,
    Theo_Sad,
    Theo_Sob,
    Theo_Cry,
    Theo_ShockGood,
    Theo_ShockBad,

    Supervisor,
    Supervisor_Happy,
    Supervisor_Angry,

    Bowie,
    Bowie_Angry,
    Bowie_Happy,
    Bowie_Sad,
    Bowie_MadDrawings,
    
    ManagerColeson,
    Random,
    Branch
};
