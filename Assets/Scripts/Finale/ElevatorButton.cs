using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    int detectedPlayers = 0;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(detectsPlayer()) {
            if(!sr.enabled) {
                sr.enabled = true;
            }
        }
        else if(sr.enabled) {
            sr.enabled = false;
        }
    }

    public bool detectsPlayer() {
        return detectedPlayers > 0;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            detectedPlayers += 1;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            detectedPlayers -= 1;
        }
    }
}
