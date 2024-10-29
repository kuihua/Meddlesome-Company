using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private string currentState;

    private PlayerMovement pm;
    private float facingDirection;

    public string Name;
    private string IdleLeft, IdleRight;
    private string WalkLeft, WalkRight;
    private string JumpLeft, JumpRight;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        facingDirection = 1;

        IdleLeft = Name + "_Idle_Left";
        IdleRight = Name + "_Idle_Right";
        WalkLeft = Name + "_Walk_Left";
        WalkRight = Name + "_Walk_Right";
        JumpLeft = Name + "_Jump_Left";
        JumpRight = Name + "_Jump_Right";
    }

    // Update is called once per frame
    void Update()
    {
        if(pm.horizontalInput != 0) {
            facingDirection = pm.horizontalInput;
        }

        if(!pm.onGround) {
            // jump
            if(facingDirection > 0) {
                ChangeAnimationState(JumpRight);
            }
            else if(facingDirection < 0) {
                ChangeAnimationState(JumpLeft);
            }
        }
        else if(pm.horizontalInput > 0) {
            // walk right
            ChangeAnimationState(WalkRight);
        }
        else if(pm.horizontalInput < 0) {
            // walk left
            ChangeAnimationState(WalkLeft);
        }
        else if(facingDirection > 0) {
            // idle right
            ChangeAnimationState(IdleRight);
        }
        else if(facingDirection < 0) {
            // idle left
            ChangeAnimationState(IdleLeft);
        }
    }

    public void ChangeAnimationState(string newState) {
        if(currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
