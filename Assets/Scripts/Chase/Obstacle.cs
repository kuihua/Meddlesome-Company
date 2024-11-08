using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // void OnTriggerEnter2D(Collider2D collider) {
    //     if(collider.CompareTag("Player")) {
    //         collider.GetComponent<PlayerMovement>().Slow(3, 3);
    //     }
    // }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            GameObject player = collision.gameObject;
            player.GetComponent<PlayerMovement>().Slow(3, 2);
            float dir;
            if(player.GetComponent<Rigidbody2D>().velocity.x > 0) {
                dir = 1;
            }
            else {
                dir = -1;
            }
            rb.velocity = new Vector2(8 * dir, 10);
            rb.AddTorque(-10 * dir, ForceMode2D.Impulse);
            Physics2D.IgnoreCollision(collision.collider, GetComponent<BoxCollider2D>(), true);
        }
    }
}
