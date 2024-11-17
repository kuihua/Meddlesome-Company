using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpot : MonoBehaviour
{
    public Sprite hideIcon, leaveIcon;
    // bool available;
    GameObject hidingPlayer;

    SpriteRenderer sr;
    bool playerDetected;
    
    PlayerController controller;
    List<GameObject> activePlayers;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player Controller").GetComponent<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
        activePlayers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hidingPlayer == null) {
            if(activePlayers.Contains(controller.CurrentPlayer)) {
                playerDetected = true;
            }
            else {
                playerDetected = false;
            }
        }
        else {
            if(controller.CurrentPlayer == hidingPlayer) {
                playerDetected = true;
                controller.CurrentPlayer.GetComponent<PlayerMovement>().enabled = false;
                // controller.HidePlayer(true);
            }
            else {
                playerDetected = false;
            }
        }

        if(playerDetected) {
            if(!sr.enabled) {
                sr.enabled = true;
            }
            if(Input.GetKeyDown(KeyCode.E)) {
                if(hidingPlayer == null) {
                    // hide player
                    controller.HidePlayer(true);
                    hidingPlayer = controller.CurrentPlayer;
                    sr.sprite = leaveIcon;
                }
                else {
                    // unhide player
                    controller.HidePlayer(false);
                    hidingPlayer = null;
                    sr.sprite = hideIcon;
                }
            }
        }
        else if(sr.enabled) {
            sr.enabled = false;
        }
    }

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
}
