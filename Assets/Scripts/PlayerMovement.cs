using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float moveSpeed = 5;
    private float jumpForce = 10;

    private float horizontalInput;

    private bool onGround;

    [SerializeField] private AudioClip jumpSoundClip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

// if paused, don't jump
        if(Input.GetKeyDown(KeyCode.Space) && onGround && !PauseMenu.gameIsPaused) {
            // jump();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            SoundFXManager.instance.PlaySoundFXClip(jumpSoundClip, transform, 1f);
        }
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y); // horizontalInput * moveSpeed;
        // rb.velocityX = horizontalInput * moveSpeed;
    }

    // private void jump() {
    //     rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    //     onGround = false;
    // }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground") {
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground") {
            onGround = false;
        }
    }
}
