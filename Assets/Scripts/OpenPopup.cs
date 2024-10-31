using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPopup : MonoBehaviour
{
    public GameObject popupWindow;
    public GameObject Player;

    private SpriteRenderer sr;
    private bool playerDetected;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerDetected && Player != null) {
            Player.GetComponent<PlayerMovement>().Stop();
            Player.GetComponent<PlayerMovement>().enabled = false;
            popupWindow.SetActive(true);
        }
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
            playerDetected = false;
            sr.enabled = false;
            Player = null;
        }
    }
}
