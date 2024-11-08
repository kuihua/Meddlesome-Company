using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using System;

public class NPCDialogue : MonoBehaviour
{

    // private Transform player;
    private SpriteRenderer speechIcon;
    [SerializeField] private bool hasIcon;

    // for dialogue triggers
    [SerializeField] private bool isDialogueTrigger;
    [SerializeField] private bool dialogueTriggered;


    [SerializeField] public DialogueSO cutsceneConversation;
    private bool isCutscene;

    public DialogueSO[] conversation; 

    private DialogueManager dialogueManager;
    private bool dialogueInitiated;
    private bool cutsceneTriggered;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();

        // if its an npc, activate speech icon
        if (hasIcon) {
            speechIcon = GetComponent<SpriteRenderer>();
            speechIcon.enabled = false;
        }
    }

    private void OnTriggerStay2D (Collider2D collider) {
        // Debug.Log("stay");
        if (collider.gameObject.tag == "Player" && !dialogueInitiated){
            // speech bubble on
            if (hasIcon) {
                speechIcon.enabled = true;
            }

            // // find the player's transform
            // player = collider.gameObject.GetComponent<Transform>();

            // // check to see where the player is, and then turn towards him
            // if (player.position.x > transform.position.x && transform.parent.localScale.x < 0) {
            //     Flip();
            // } else if (player.position.x < transform.position.x && transform.parent.localScale.x > 0) {
            //     Flip();
            // }

            // dialogueManager.InitiateDialogue(this);
            // dialogueInitiated = true;

            // for trigger dialogues, if it has already been activated, it won't activate
            if(!dialogueTriggered && cutsceneTriggered) {
                dialogueManager.InitiateDialogue(this);
                dialogueInitiated = true;
            }

            
            // isDialogueTrigger = true;

        }
    }

    private void OnTriggerExit2D (Collider2D collider) {
        if (collider.gameObject.tag == "Player"){
            // speech bubble off
            if (hasIcon) {
                speechIcon.enabled = false;
            }

            dialogueManager.TurnOffDialogue();
            dialogueInitiated = false;
        }
    }
    public void activateCutsceneDialogue() {
        if (!cutsceneTriggered) {
            Debug.Log("activating cutscene");
            dialogueInitiated = true;
            isCutscene = true;
            // cutsceneTriggered = true;
            dialogueManager.InitiateDialogue(this);
        } 
    }

    public DialogueSO setCutsceneDialogue(DialogueSO cDialogue) {
        cutsceneConversation = cDialogue;
        return cutsceneConversation;
    }

    public bool GetIsTrigger() {
        return isDialogueTrigger;
    }

    public void SetIsTrigger(bool triggered) {
        dialogueTriggered = triggered; 
    }


    public bool GetIsCutscene() {
        return isCutscene;
    }

    public void SetCutsceneTriggered(bool triggered) {
        cutsceneTriggered = triggered; 
    }


    public DialogueSO GetCutsceneDialogue() {
        return cutsceneConversation;
    }

    // public void SetCutsceneDone(bool completed) {
    //     cutsceneDone = completed; 
    // }

    // private void Flip() {
    //     Vector3 currentScale = transform.parent.localScale;
    //     currentScale.x *= -1;
    //     transform.parent.localScale = currentScale;
    // }

}
