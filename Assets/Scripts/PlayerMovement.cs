using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float moveSpeed;
    private float maxSpeed = 8;
    private float jumpForce = 15;

    public float horizontalInput;

    public bool onGround;

    private float timer = 0;

    public bool inCutscene = false;

    [SerializeField] private AudioClip jumpSoundClip;
    // [SerializeField] private DialogueUI dialogueUI;
    // public DialogueUI DialogueUI => dialogueUI;
    // public IInteractable Interactable {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    { 
        // if in dialogue or paused, don't move
        // known bug. if moving when opening dialogue, player still moves
        if (PauseMenu.gameIsPaused) {
            return;
        }

        // if in cutscene, disable player movement
        if (!inCutscene){
            horizontalInput = Input.GetAxisRaw("Horizontal");
            // Debug.Log(horizontalInput);

            if(Input.GetKeyDown(KeyCode.Space) && onGround) {
                // jump();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                SoundFXManager.instance.PlaySoundFXClip(jumpSoundClip, transform, 1f);
            }
        } else {
            horizontalInput = 0;
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
        if(timer > 0) {
            timer -= Time.fixedDeltaTime;
            if(timer <= 0) {
                moveSpeed = maxSpeed;
            }
        }
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

    public void Stop() {
        rb.velocity = new Vector2(0, rb.velocity.y);
        horizontalInput = 0;
    }

    public void StopCompletely() {
        rb.velocity = new Vector2(0, 0);
        horizontalInput = 0;
    }

    public void Slow(float speed, float time) {
        moveSpeed = speed;
        timer = time;
    }

    public void SetInCutscene(bool cs) {
        inCutscene = cs;
    }
}
