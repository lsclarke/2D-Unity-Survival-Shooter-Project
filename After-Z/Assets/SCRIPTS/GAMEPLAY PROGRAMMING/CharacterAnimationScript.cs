using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEditor.VersionControl.Asset;

public class CharacterAnimationScript : MonoBehaviour
{

    //Animator Variables - To access animator to control animation states
    public MovementScript movementScript;
    public CharacterJumpScript jumpScript;
    [SerializeField]
    private Animator animator;


    //Enum Variables - To control the state of animations 
    private enum AnimationStates { idle, run, jump, shooting, crouch, die }
    [SerializeField]
    private AnimationStates state;

    //Bool Variables - For current state conditions
    private bool isMoving;
    private bool isJumping;
    private bool isCrouched;
    private bool isFacingRight;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isFacingRight = true;
        
    }

    private void FixedUpdate()
    {
        //Flip the animation based on the speed/direction the player is going in
        //and check to see if it is facing right

        if (movementScript.moveX < 0f && isFacingRight)
        {
            FlipAnimation();
        }

        if (movementScript.moveX > 0f && !isFacingRight)
        {
            FlipAnimation();
        }

    }

    private void FlipAnimation()
    {
        //Get the current scale of the player and then multiply it by 1 to constantly flip between pos and neg
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void AnimationStatesBehavior()
    {
        //Check the value of the movement on the horizontal axis of the player
        //based on the value change from idle to run state
        if (Mathf.Abs(movementScript.moveX) > 0.1f && jumpScript.isGrounded())
        {
            state = AnimationStates.run;
            isMoving = true;
            Debug.Log("State: " + state);

        }
        else
        {
            state = AnimationStates.idle;
            isMoving = false;
        }


        //If the player is mooving and performs the crouch button
        //the player will transition from a slide to a crouch state
        if (movementScript.isSliding && jumpScript.isGrounded())
        {
            state = AnimationStates.crouch;
            isCrouched = true;
            Debug.Log("State: " + state);
        }else if (movementScript.isCrouched && jumpScript.isGrounded())
        {
            state = AnimationStates.crouch;
            isCrouched = true;
            Debug.Log("State: " + state);
        }
        else
        {
            isCrouched = false;
        }

        if (!jumpScript.isGrounded())
        {
            state = AnimationStates.jump;
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        animator.SetInteger("MoveStates", (int)state);
    }






    private void Update()
    {
        AnimationStatesBehavior();
    }
}
