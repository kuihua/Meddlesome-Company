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
                // ChangeAnimationState(Name + "_Jump_Right");
            }
            else if(facingDirection < 0) {
                ChangeAnimationState(JumpLeft);
                // ChangeAnimationState(Name + "_Jump_Left");
            }
        }
        else if(pm.horizontalInput > 0) {
        // else if(pm.rb.velocity.x > 0) {
            // walk right
            ChangeAnimationState(WalkRight);
            // ChangeAnimationState(Name + "_Walk_Right");
        }
        else if(pm.horizontalInput < 0) {
        // else if(pm.rb.velocity.x < 0) {
            // walk left
            ChangeAnimationState(WalkLeft);
            // ChangeAnimationState(Name + "_Walk_Left");
        }
        else if(facingDirection > 0) {
            // idle right
            ChangeAnimationState(IdleRight);
            // ChangeAnimationState(Name + "_Idle_Right");
        }
        else if(facingDirection < 0) {
            // idle left
            ChangeAnimationState(IdleLeft);
            // ChangeAnimationState(Name + "_Idle_Left");
        }
    }

    public void ChangeAnimationState(string newState) {
        if(currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    public void ChangeName(string newName) {
        Name = newName;
        IdleLeft = Name + "_Idle_Left";
        IdleRight = Name + "_Idle_Right";
        WalkLeft = Name + "_Walk_Left";
        WalkRight = Name + "_Walk_Right";
        JumpLeft = Name + "_Jump_Left";
        JumpRight = Name + "_Jump_Right";
    }

    public void FaceLeft() {
        facingDirection = -1;
    }

    public void FaceRight() {
        facingDirection = 1;
    }
}
