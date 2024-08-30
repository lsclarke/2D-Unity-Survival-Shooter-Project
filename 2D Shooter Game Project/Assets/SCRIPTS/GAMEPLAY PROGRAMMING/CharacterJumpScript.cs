using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterJumpScript : MonoBehaviour
{


    [Header("Refernce Settings")]
    [SerializeField]
    public CharacterScript characterScript;
    [SerializeField]
    public Rigidbody2D rb2D;
    [SerializeField]
    public PlayerInput input;

    //Movement Variables
    [Header("Speed Settings")]
    public float jumpForce;

    [Header("Bool Variables")]
    //bool variables
    private bool isJumping;
    private bool grounded;

    [Header("Ground Collision Settings")]
    public LayerMask groundLayer;
    public Transform groundcheckLoc;

    [Range(0.0f, 10.0f)]
    public float groundcheckRadius;


    private void Awake()
    {
        //Initialize Classes
        characterScript = GetComponent<CharacterScript>();
        rb2D = GetComponent<Rigidbody2D>();
        
        //Set jump to Character Script jump var
        jumpForce = characterScript.getJumpPower();

    }
    private void FixedUpdate()
    {
        grounded = isGrounded();

        jumpForce = characterScript.getJumpPower();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        context.ReadValue<float>();

        if (context.performed && isGrounded())
        {
            //rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        if (context.canceled && rb2D.velocity.y > 0f)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }
    }


    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundcheckLoc.position, groundcheckRadius, groundLayer);

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundcheckLoc.position, groundcheckRadius);
    }
}
