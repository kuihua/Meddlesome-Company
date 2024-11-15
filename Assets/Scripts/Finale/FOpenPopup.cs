using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOpenPopup : MonoBehaviour
{
    public GameObject popupWindow;
    SpriteRenderer sr;
    bool playerDetected;
    
    PlayerController controller;
    List<GameObject> activePlayers;

    public GameObject specificPlayer;

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
            if(!sr.enabled) {
                sr.enabled = true;
            }
            if(Input.GetKeyDown(KeyCode.E)) {
                controller.CanMove(false);
                popupWindow.SetActive(true);
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
