using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D _rb2D;
    public float _xAxis;
    public float _yAxis;
    
    //Coyote time//
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    //Jump buffer//
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private bool IsJumping;

    [SerializeField] private float xForce; // movement speed;
    [SerializeField] private float yForce; // Jump Power;

    private CapsuleCollider2D _capsuleCollider2D;// for ground check;
    [SerializeField] private LayerMask canJump;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    private void Update()
    {
       _xAxis = Input.GetAxisRaw("Horizontal");
        if(IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        //Player can still jump after leaving the ground for a few seconds (0.2f)//

        if(Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f) //quick tap of the jump button//
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, yForce);
            jumpBufferCounter = 0f;
            //Jump cut//
        }
        if(Input.GetButtonUp("Jump") && _rb2D.velocity.y > 0f) // Holding the jump button//
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _rb2D.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
            //Increase jump height//
        }
    }
    private void FixedUpdate()
    {
        _yAxis = Input.GetAxisRaw("Vertical");
        //for horizontal movements (left and right)//
        _rb2D.velocity = new Vector2(_xAxis * xForce, _rb2D.velocity.y);
    }
    private bool IsGrounded() // CHECKING IF PLAYER IS GROUNDED//
    {
       var bounds = _capsuleCollider2D.bounds; // COLLIDER FOR GROUND CHECK//
       return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, 0.2f, canJump);
        //COLLIDER SETTINGS//
    }
}
