using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWarp : MonoBehaviour
{
    public GameObject Player;
    public Vector2 NewLocation;
    public Transform target;
    public ScreenFader Sf;

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
        if(Input.GetKeyDown(KeyCode.E) && playerDetected //&& Player != null
        && Player.GetComponent<PlayerMovement>().enabled) {
            StartCoroutine(warp());
        }
    }

    IEnumerator warp() {
        Debug.Log("start");
        Player.GetComponent<PlayerMovement>().Stop();
        Player.GetComponent<PlayerMovement>().enabled = false;
        yield return StartCoroutine(Sf.FadeToBlack());
        // Player.transform.position = NewLocation;
        Player.transform.position = target.position;
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(Sf.FadeToClear());
        Player.GetComponent<PlayerMovement>().enabled = true;
        Debug.Log("end");
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            playerDetected = true;
            // Player = collider.gameObject;
            sr.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            playerDetected = false;
            sr.enabled = false;
            // Player = null;
        }
    }
}
