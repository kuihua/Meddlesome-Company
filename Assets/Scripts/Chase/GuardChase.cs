using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardChase : MonoBehaviour
{
    Rigidbody2D rb;
    ChaseScene chase;

    Animator animator;
    string currentState;
    public int facingDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        chase = GameObject.Find("Chase Manager").GetComponent<ChaseScene>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x > 0) {
            ChangeAnimationState("Guard_Walk_Right");
        }
        else if(rb.velocity.x < 0) {
            ChangeAnimationState("Guard_Walk_Left");
        }
        else if(facingDirection > 0) {
            ChangeAnimationState("Guard_Idle_Right");
        }
        else if(facingDirection < 0) {
            ChangeAnimationState("Guard_Idle_Left");
        }
    }

    IEnumerator OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            PlayerMovement pm = collider.GetComponent<PlayerMovement>();
            if(pm.enabled) {
                pm.Stop();
                pm.enabled = false;
                rb.velocity = new Vector2(0, 0);
                print("caught");
                yield return StartCoroutine(chase.Caught());
            }   
        }
    }

    public void ChangeAnimationState(string newState) {
        if(currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
