using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string sceneName;

    GameObject Player;
    ScreenFader Sf;

    private SpriteRenderer sr;
    private bool playerDetected;

    // Start is called before the first frame update
    void Start()
    {
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
        sr = GetComponent<SpriteRenderer>();

        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerDetected
        && Player.GetComponent<PlayerMovement>().enabled) {
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene() {
        Player.GetComponent<PlayerMovement>().Stop();
        Player.GetComponent<PlayerMovement>().enabled = false;
        yield return StartCoroutine(Sf.FadeToBlack());
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            playerDetected = true;
            sr.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            playerDetected = false;
            sr.enabled = false;
        }
    }
}
