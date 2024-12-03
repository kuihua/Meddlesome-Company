using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSpot : MonoBehaviour
{
    SoundArea area;

    SpriteRenderer sr;
    bool playerDetected;
    
    PlayerController controller;
    List<GameObject> activePlayers;

    [SerializeField] private AudioClip phoneSoundClip;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player Controller").GetComponent<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
        activePlayers = new List<GameObject>();

        // area = GetComponentInChildren<SoundArea>();
        area = transform.GetChild(0).gameObject.GetComponent<SoundArea>();
    }

    // Update is called once per frame
    void Update()
    {
        if(activePlayers.Contains(controller.CurrentPlayer)) {
            playerDetected = true;
        }
        else {
            playerDetected = false;
        }

        if(playerDetected) {
            if(!sr.enabled) {
                sr.enabled = true;
            }
            if(Input.GetKeyDown(KeyCode.E)) {
                SoundFXManager.instance.PlaySoundFXClip(phoneSoundClip, transform, 0.5f);
                // Debug.Log("E");
                foreach(GuardStealth guard in area.inRange) {
                    guard.distract(transform.position.x);
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
