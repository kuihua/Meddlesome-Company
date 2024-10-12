using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWarp : MonoBehaviour
{
    public GameObject Player;
    public Vector2 NewLocation;
    public ScreenFader Sf;

    private SpriteRenderer sr;
    private bool playerDetected;

    // Start is called before the first frame update
    void Start()
    {
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerDetected && Player != null) {
            StartCoroutine(warp());
        }
    }

    IEnumerator warp() {
        yield return StartCoroutine(Sf.FadeToBlack());
        // Controller.GetComponent<PlayerControl>().getCurrentPlayer().position = NewLocation;
        Player.transform.position = NewLocation;
        // yield return new WaitForSeconds(0.5);
        yield return StartCoroutine(Sf.FadeToClear());
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            playerDetected = true;
            Player = collider.gameObject;
            sr.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            playerDetected = true;
            sr.enabled = false;
            Player = null;
        }
    }
}
