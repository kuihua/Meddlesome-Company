using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardStealth : MonoBehaviour
{
    GameObject leftView, rightView;
    // Transform ogPos;
    float ogX, targetX;
    public int ogFacingDirection;
    public int facingDirection;

    Animator animator;
    string currentState;
    string IdleLeft, IdleRight;
    string WalkLeft, WalkRight;

    Rigidbody2D rb;
    float moveSpeed = 5;
    float distractedTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        leftView = transform.GetChild(0).gameObject;
        rightView = transform.GetChild(1).gameObject;

        IdleLeft = "Guard_Idle_Left";
        IdleRight = "Guard_Idle_Right";
        WalkLeft = "Guard_Walk_Left";
        WalkRight = "Guard_Walk_Right";

        // ogPos = transform;
        ogX = transform.position.x;
        facingDirection = ogFacingDirection;
        if(facingDirection > 0) {
            // face right
            leftView.SetActive(false);
            ChangeAnimationState(IdleRight);
        }
        else if(facingDirection < 0) {
            // face left
            rightView.SetActive(false);
            ChangeAnimationState(IdleLeft);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x > 0) {
            facingDirection = 1;
            ChangeAnimationState(WalkRight);
            // Debug.Log("walk right");
        }
        else if(rb.velocity.x < 0) {
            facingDirection = -1;
            ChangeAnimationState(WalkLeft);
            // Debug.Log("walk left");
        }
        else if(facingDirection > 0) {
            ChangeAnimationState(IdleRight);
            // Debug.Log("idle right");
        }
        else if(facingDirection < 0) {
            ChangeAnimationState(IdleLeft);
            // Debug.Log("idle left");
        }

        if(facingDirection > 0 && leftView.activeSelf) {
            // face right
            leftView.SetActive(false);
            rightView.SetActive(true);
            // ChangeAnimationState(IdleRight);
        }
        else if(facingDirection < 0 && rightView.activeSelf) {
            // face left
            rightView.SetActive(false);
            leftView.SetActive(true);
            // ChangeAnimationState(IdleLeft);
        }
        // string more = (rb.velocity.x > 0).ToString();
        // string less = (rb.velocity.x < 0).ToString();
        // Debug.Log(more + " " + less);
    }

    void FixedUpdate() {
        // movement stuff
        if(distractedTimer <= 0) {
            // move back
            moveToward(ogX);
        }
        else if(distractedTimer > 0) {
            distractedTimer -= Time.fixedDeltaTime;
            moveToward(targetX);
        }
    }

    public void distract(float newX) {
        distractedTimer = 8;
        targetX = newX;
    }

    void moveToward(float newX) {
        // if(transform.position.x != newX) {
        float buffer;
        if(newX == ogX) {
            buffer = 0.1f;
        } else {
            buffer = 2;
        }
        if(Mathf.Abs(transform.position.x - newX) > buffer) {
            rb.velocity = new Vector2(newX - transform.position.x, 0).normalized * moveSpeed;
        } else {
            rb.velocity = new Vector2(0, 0);
            if(newX == ogX) {
                facingDirection = ogFacingDirection;
            }
        }
    }

    public void ChangeAnimationState(string newState) {
        if(currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
