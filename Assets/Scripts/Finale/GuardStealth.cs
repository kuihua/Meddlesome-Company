using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardStealth : MonoBehaviour
{
    GameObject leftView, rightView;
    Transform ogPos;
    public int ogFacingDirection;
    public int facingDirection;

    Animator animator;
    string currentState;
    string IdleLeft, IdleRight;
    string WalkLeft, WalkRight;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        leftView = transform.GetChild(0).gameObject;
        rightView = transform.GetChild(1).gameObject;

        IdleLeft = "Guard_Idle_Left";
        IdleRight = "Guard_Idle_Right";
        WalkLeft = "Guard_Walk_Left";
        WalkLeft = "Guard_Walk_Right";

        ogPos = transform;
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
        if(facingDirection > 0 && leftView.activeSelf) {
            // face right
            leftView.SetActive(false);
            rightView.SetActive(true);
            ChangeAnimationState(IdleRight);
        }
        else if(facingDirection < 0 && rightView.activeSelf) {
            // face left
            rightView.SetActive(false);
            leftView.SetActive(true);
            ChangeAnimationState(IdleLeft);
        }
    }

    void FixedUpdate() {
        // movement stuff
    }

    public void ChangeAnimationState(string newState) {
        if(currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
