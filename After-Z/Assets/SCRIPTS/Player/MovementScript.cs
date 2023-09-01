using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    //Reference Variables - Access Character Script and obtain variable data
    [Header("Refernce Settings")]
    [SerializeField]
    public CharacterScript characterScript;
    [SerializeField]
    public Rigidbody2D rb2D;
    [SerializeField]
    public PlayerInput input;

    //Movement Variables
    [Header("Speed Settings")]
    public float moveSpeed;
    private float crouchSlideSpeed;

    [Header("Input Settings")]
    public float moveX;
    public float moveY;

    //bool variables

    private bool isMoving;
    public bool isCrouched;
    public bool isSliding;


    private void Awake()
    {
        //Initialize Classes
        characterScript = GetComponent<CharacterScript>();
        rb2D = GetComponent<Rigidbody2D>();

        //Set Speed to Character Script speed var
        moveSpeed = characterScript.getSpeed();

        Debug.Log("MOVE SPEED: " + characterScript.getSpeed());
    }

    private void FixedUpdate()
    {
        MovementHandler();

        if (Mathf.Abs(moveX) > 0.1f) { isMoving = true; }

    }
  
    public void Movement(InputAction.CallbackContext context)
    {
        moveX = context.ReadValue<Vector2>().x;
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        if(context.performed && isMoving)
        {
            isSliding = true;
        }else if (context.performed && !isMoving)
        {
            isCrouched = true;
        }
        else
        {
            isCrouched=false;
            isSliding = false;
            moveSpeed = characterScript.getSpeed(); 
        }
    }


    private void MovementHandler()
    {
        rb2D.velocity = new Vector2(moveX * moveSpeed, rb2D.velocity.y);
    }

    private void Update()
    {
        if(isSliding && moveSpeed > 0) { 
            moveSpeed -= Time.deltaTime * 4f;

            if (moveSpeed <= 0) { moveSpeed = 0; }

        }
        if(isCrouched && !isMoving && moveSpeed > 0)
        {
            moveSpeed = 0;
            if (moveSpeed <= 0) { moveSpeed = 0; }
        }
    }
}
