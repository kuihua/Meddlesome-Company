using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FActivateCutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector; // timeline to play

    [Header("Activate Cutscene With E. Disables after.")]
    public bool isPressKeyToActivate;
    private bool playerDetected;
    // public GameObject Player;
    // public string designatedPlayer;
    public bool hasPlayed; // for testing
    [Header("Is it after a puzzle")]
    public bool afterPuzzle; 

    private SpriteRenderer sr;
    [Header("Does GO have non cutscene stuff")]
    public bool hasOtherStuff;

    PlayerController controller;
    List<GameObject> activePlayers;

    public GameObject specificPlayer;


    void Start()
    {
        controller = GameObject.Find("Player Controller").GetComponent<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
        activePlayers = new List<GameObject>();
    }

    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.E) && playerDetected && Player != null) {
        //     ActivateCutsceneKey();
        // }

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

        if(playerDetected) {
            if(sr != null) {
                if (!sr.enabled)
                sr.enabled = true;
            }
            if(Input.GetKeyDown(KeyCode.E) && isPressKeyToActivate) {
                ActivateCutsceneKey();
            } else if (!isPressKeyToActivate && !afterPuzzle){
                playableDirector.Play();
            }
        }
        else if(sr != null) {
            if (sr.enabled)
                sr.enabled = false;
        }

    }

    // activate the cutscene if the player enters the trigger area
    // disables the trigger afterwards so it won't happen again
    // private void OnTriggerStay2D (Collider2D collision) {
    //     if (collision.name.Equals(designatedPlayer) && !isPressKeyToActivate && !afterPuzzle){
    //         playableDirector.Play();
    //         GetComponent<BoxCollider2D>().enabled = false;
    //     } else if (collision.name.Equals(designatedPlayer)) {
    //         playerDetected = true;
    //         Player = collision.gameObject;
    //         // if(sr != null) {
    //         //     sr.enabled = true;
    //         // }
    //     }
    // }

    // void OnTriggerExit2D(Collider2D collision) {
    //     if(playerDetected) {
    //         playerDetected = false;
    //         Player = null;
    //         if(sr != null) {
    //             sr.enabled = false;
    //         }
    //     }
    // }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            GameObject player = collider.gameObject;
            if(!activePlayers.Contains(player)) {
                activePlayers.Add(player);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            GameObject player = collider.gameObject;
            if(activePlayers.Contains(player)) {
                activePlayers.Remove(player);
            }
        }
    }

    public void ActivateCutsceneKey () {
        // function to play cutscene, disables this script when its done
        playableDirector.Play();
        GetComponent<FActivateCutscene>().enabled = false;
        // disables sprite; for triggers from talking to npcs because the speech icon will show
        if (GetComponent<SpriteRenderer>() != null && !hasOtherStuff){
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
