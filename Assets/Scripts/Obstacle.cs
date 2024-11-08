using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;
    // bool hit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(hit) {
        //     rb.angularVelocity = 15;
        // }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            collider.GetComponent<PlayerMovement>().Slow(3, 3);
        }
    }

    // void OnTriggerExit2D(Collider2D collider) {
    //     if(collider.CompareTag("Player")) {
            
    //     }
    // }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            print("collide");
            collision.gameObject.GetComponent<PlayerMovement>().Slow(3, 3);
            rb.velocity = new Vector2(-8, 10);
            rb.AddTorque(10, ForceMode2D.Impulse);
            Physics2D.IgnoreCollision(collision.collider, GetComponent<BoxCollider2D>(), true);
        }
    }
}
