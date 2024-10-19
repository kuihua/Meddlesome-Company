using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{

    private Transform player;
    private SpriteRenderer speechIcon;

    public DialogueSO[] conversation; 
    private DialogueManager dialogueManager;
    private bool dialogueInitiated;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();

        speechIcon = GetComponent<SpriteRenderer>();
        speechIcon.enabled = false;
    }

    private void OnTriggerStay2D (Collider2D collider) {
        if (collider.gameObject.tag == "Player" && !dialogueInitiated){
            // speech bubble on
            speechIcon.enabled = true;

            // find the player's transform
            player = collider.gameObject.GetComponent<Transform>();

            // check to see where the player is, and then turn towards him
            if (player.position.x > transform.position.x && transform.parent.localScale.x < 0) {
                Flip();
            } else if (player.position.x < transform.position.x && transform.parent.localScale.x > 0) {
                Flip();
            }

            dialogueManager.InitiateDialogue(this);
            dialogueInitiated = true;

        }
    }

    private void OnTriggerExit2D (Collider2D collider) {
        if (collider.gameObject.tag == "Player"){
            // speech bubble off
            speechIcon.enabled = false;

            dialogueManager.TurnOffDialogue();
            dialogueInitiated = false;
        }
    }

    private void Flip() {
        Vector3 currentScale = transform.parent.localScale;
        currentScale.x *= -1;
        transform.parent.localScale = currentScale;
    }
}
