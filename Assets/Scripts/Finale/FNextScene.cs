using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FNextScene : MonoBehaviour
{
    public string sceneName;

    ScreenFader Sf;

    private SpriteRenderer sr;
    private bool playerDetected;
    public bool isTrigger;

    PlayerController controller;
    List<GameObject> activePlayers;

    // Start is called before the first frame update
    void Start()
    {
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
        sr = GetComponent<SpriteRenderer>();
        controller = GameObject.Find("Player Controller").GetComponent<PlayerController>();
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
                    StartCoroutine(LoadNextScene());
                }
            }
            else if(sr != null && sr.enabled) {
                sr.enabled = false;
            }
        }
    }

    IEnumerator LoadNextScene() {
        controller.CanMove(false);
        yield return StartCoroutine(Sf.FadeToBlack());
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            GameObject player = collider.gameObject;
            if(isTrigger && player == controller.CurrentPlayer) {
                StartCoroutine(LoadNextScene());
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
}
