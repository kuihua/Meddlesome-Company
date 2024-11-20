using UnityEngine;
using UnityEngine.Playables;
using System.Collections.Generic;

public class FNPCDialogue : MonoBehaviour
{

    // private Transform player;
    private SpriteRenderer speechIcon;
    [SerializeField] private bool hasIcon;

    // for dialogue triggers
    [Header("Dialogue Trigger Area")][SerializeField] 
    private bool isDialogueTrigger;

    [Header("Triggered Diaglogue Trigger Area")]
    [SerializeField] private bool dialogueTriggered;


    // [SerializeField] public DialogueSO cutsceneConversation;
    private bool isCutscene;

    [SerializeField]
    public DialogueSO[] conversation; 

    private FDialogueManager dialogueManager;
    private bool dialogueInitiated;

    // cutscene
    private bool cutsceneTriggered;

    [Header("From Cutscene Timeline")]
    [SerializeField] PlayableDirector playableDirector;

    PlayerController controller;
    List<GameObject> activePlayers;

    public GameObject specificPlayer;
    bool playerDetected;
    private bool isNPCExamine;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<FDialogueManager>();
        controller = GameObject.Find("Player Controller").GetComponent<PlayerController>();
        activePlayers = new List<GameObject>();

        // if its an npc, activate speech icon
        if (hasIcon) {
            speechIcon = GetComponent<SpriteRenderer>();
            speechIcon.enabled = false;
        }
    }
    
    void Update() {
        if(activePlayers.Contains(controller.CurrentPlayer)) {
            if(specificPlayer != null) {
                if(controller.CurrentPlayer == specificPlayer) {
                    playerDetected = true;
                }
                else {
                    playerDetected = false;
                }
            }
            else {
                playerDetected = true;
            }
        }
        else {
            playerDetected = false;
        }


    } // end of update

    private void OnTriggerStay2D (Collider2D collider) {
        if(collider.CompareTag("Player")) {
            GameObject player = collider.gameObject;
            if(!activePlayers.Contains(player)) {
                activePlayers.Add(player);
            }
        }

        // Debug.Log("stay");
        if (!dialogueInitiated && playerDetected){
            // speech bubble on
            if (hasIcon) {
                speechIcon.enabled = true;
            }

            // for trigger area dialogues, if it has already been activated, it won't activate again when going through the same area again
            if(!dialogueTriggered) {
                dialogueManager.InitiateDialogue(this);
                dialogueInitiated = true;
            }
        }
    } // end of OnTriggerStay2D

    // turn speech icon off and stop dialogue and remove ability to talk to the npc out of range
    private void OnTriggerExit2D (Collider2D collider) {
        if(collider.CompareTag("Player")) {
            GameObject player = collider.gameObject;
            if(activePlayers.Contains(player)) {
                activePlayers.Remove(player);
            }
        }

        if (playerDetected){
            // speech bubble off
            if (hasIcon) {
                speechIcon.enabled = false;
            }

            dialogueManager.TurnOffDialogue();
            dialogueInitiated = false;
        }
    }

    // function to call in a timeline to be used in a cutscene
    public void activateCutsceneDialogue() {
        if (!cutsceneTriggered) {
            // Debug.Log("activating cutscene");
            dialogueInitiated = true;
            isCutscene = true;
            // cutsceneTriggered = true;
            dialogueManager.InitiateDialogue(this);
        } 
    }

    public void activateNPCExamineDialogue() {
        dialogueInitiated = true;
        isNPCExamine = true;
        dialogueManager.InitiateDialogue(this);
    }


    // getters and setters
    public bool GetIsTrigger() {
        return isDialogueTrigger;
    }

    public void SetIsTrigger(bool triggered) {
        dialogueTriggered = triggered; 
    }

    public bool GetIsCutscene() {
        return isCutscene;
    }

    public DialogueSO[] GetDialogue() {
        return conversation;
    }

    public bool GetIsNPCExamine() {
        return isNPCExamine;
    }

    public PlayableDirector GetPlayableDirector() {
        return playableDirector;
    }

}
