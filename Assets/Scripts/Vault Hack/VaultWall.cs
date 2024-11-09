using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VaultWall : MonoBehaviour
{
    public int minHealth;
    public OpenPopup popupInteract;
    GameObject Player;
    Image img;
    int health = 10;
    int hits = 0;
    int successfulBlocks = 0;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= minHealth || successfulBlocks >= 40) {
            endMinigame();
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        // if(collider)
        Destroy(collider.gameObject);
        hits += 1;
        health -= 1;
        if(health == 9) {
            img.color = new Color(0.9f, 0.9f, 0.9f, 1);
        }
        else if(health == 8) {
            img.color = new Color(0.8f, 0.8f, 0.8f, 1);
        }
        else if(health == 7) {
            img.color = new Color(0.7f, 0.7f, 0.7f, 1);
        }
        else if(health == 6) {
            img.color = new Color(0.6f, 0.6f, 0.6f, 1);
        }
        else if(health == 5) {
            img.color = new Color(0.5f, 0.5f, 0.5f, 1);
        }
        else if(health == 4) {
            img.color = new Color(0.4f, 0.4f, 0.4f, 1);
        }
        else if(health == 3) {
            img.color = new Color(0.3f, 0.3f, 0.3f, 1);
        }
        else if(health == 2) {
            img.color = new Color(0.2f, 0.2f, 0.2f, 1);
        }
        else if(health == 1) {
            img.color = new Color(0.1f, 0.1f, 0.1f, 1);
        }

        // if(health == minHealth) {
        //     endMinigame();
        // }
    }

    void endMinigame() {
        Player.GetComponent<PlayerMovement>().enabled = true;
        if(popupInteract != null) {
            popupInteract.gameObject.SetActive(false);
        }
        transform.parent.gameObject.SetActive(false);
    }

    public int getHits() {
        return hits;
    }

    public void addBlocked() {
        successfulBlocks += 1;
    }
}
