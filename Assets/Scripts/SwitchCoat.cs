using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCoat : MonoBehaviour
{
    private GameObject Player;
    private SpriteRenderer sr;
    private bool playerDetected;

    public string newName;

    public GameObject[] appear;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerDetected && Player != null) {
            // Player.GetComponent<PlayerAnimation>().Name = newName;
            Player.GetComponent<PlayerAnimation>().ChangeName(newName);
            foreach(GameObject go in appear) {
                go.SetActive(true);
            }
            gameObject.SetActive(false);
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
