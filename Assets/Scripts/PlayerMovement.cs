using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float moveSpeed = 7;
    private float jumpForce = 15;

    public float horizontalInput;

    public bool onGround;

    [SerializeField] private AudioClip jumpSoundClip;
    // [SerializeField] private DialogueUI dialogueUI;
    // public DialogueUI DialogueUI => dialogueUI;
    // public IInteractable Interactable {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        // if in dialogue or paused, don't move
        // known bug. if moving when opening dialogue, player still moves
        if (PauseMenu.gameIsPaused) {
            return;
        }

        horizontalInput = Input.GetAxisRaw("Horizontal");
        Debug.Log(horizontalInput);

        if(Input.GetKeyDown(KeyCode.Space) && onGround) {
            // jump();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            SoundFXManager.instance.PlaySoundFXClip(jumpSoundClip, transform, 1f);
        }

        // if(Input.GetKeyDown(KeyCode.E)) {
        //     if (Interactable != null) {
        //         Interactable.Interact(this);
        //     }
        // }
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
