using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWarp : MonoBehaviour
{
    public Transform target;
    public bool isTrigger;

    ScreenFader Sf;
    SpriteRenderer sr;
    bool playerDetected;

    PlayerController controller;
    List<GameObject> activePlayers;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player Controller").GetComponent<PlayerController>();
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
        sr = GetComponent<SpriteRenderer>();
        activePlayers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isTrigger) {
            if(activePlayers.Contains(controller.CurrentPlayer)) {
                playerDetected = true;
            }
            else {
                playerDetected = false;
            }

            if(playerDetected && controller.CurrentPlayer.GetComponent<PlayerMovement>().enabled) {
                if(sr != null && !sr.enabled) {
                    sr.enabled = true;
                }
                if(Input.GetKeyDown(KeyCode.E)) {
                    StartCoroutine(warp());
                }
            }
            else if(sr != null && sr.enabled) {
                sr.enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            GameObject player = collider.gameObject;
            if(isTrigger && player == controller.CurrentPlayer) {
                StartCoroutine(warp());
            }
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

    IEnumerator warp() {
        // Debug.Log("start");
        controller.CanMove(false);
        yield return StartCoroutine(Sf.FadeToBlack());
        controller.CurrentPlayer.transform.position = target.position;
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(Sf.FadeToClear());
        controller.CanMove(true);
        // Debug.Log("end");
    }
}
