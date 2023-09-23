using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationScript : MonoBehaviour
{
    //Animator Variables - To access animator to control animation states
    public EnemyScript enemyScript;
    private CharacterScript characterScript;
    [SerializeField]
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    //Enum Variables - To control the state of animations 
    private enum AnimationStates { idle, move, die}
    [SerializeField]
    private AnimationStates state;

    //Bool Variables - For current state conditions
    private bool isMoving;
    private bool isAttacking;
    private bool isDead;
    private bool isFacingRight;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterScript = GameObject.Find("PLAYER CONTROLLER").GetComponent<CharacterScript>();

    }

    private void FixedUpdate()
    {
        //if(characterScript.transform.position.x > 0f && !isFacingRight)
        //{
        //    FlipAnimation();
        //}

        //if (characterScript.transform.position.x < 0f && isFacingRight)
        //{
        //    FlipAnimation();
        //}
    }

    private void FlipAnimation()
    {
        //Get the current scale of the player and then multiply it by 1 to constantly flip between pos and neg
        isFacingRight = !isFacingRight;
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    }

    private void AnimationStatesBehavior()
    {
        //Check the value of the movement on the horizontal axis of the player
        //based on the value change from idle to run state
        if (Mathf.Abs(enemyScript.speed) > 0.1f)
        {
            state = AnimationStates.move;
            isMoving = true;
            Debug.Log("State: " + state);

        }
        else
        {
            state = AnimationStates.idle;
            isMoving = false;
        }

        animator.SetInteger("BehaviorStates", (int)state);
    }






    private void Update()
    {
        Debug.Log("Speed: " + enemyScript.speed);
        AnimationStatesBehavior();

        if (characterScript.transform.position.x > this.transform.position.x && isFacingRight)
        {
            FlipAnimation();
        }

        if (characterScript.transform.position.x < this.transform.position.x && !isFacingRight)
        {
            FlipAnimation();
        }

    }

}
