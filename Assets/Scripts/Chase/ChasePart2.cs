using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePart2 : MonoBehaviour
{
    public GameObject GuardPrefab;
    public Transform spawnPos;
    // public int direction;
    float timer = 2;
    // public GameObject CaughtScreen;
    ScreenFader Sf;

    bool startTimer = false;
    public GameObject firstGuard;

    // Start is called before the first frame update
    void Start()
    {
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    void FixedUpdate() {
        if(startTimer && timer > 0) {
            timer -= Time.fixedDeltaTime;
            if(timer <= 0) {
                // spawn guard
                Rigidbody2D rb = (Instantiate(GuardPrefab, spawnPos.position, Quaternion.identity)).GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(-8, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            startTimer = true;
            Destroy(firstGuard);
        }
    }
}
