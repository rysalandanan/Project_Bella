using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _xAxis;
    private float _yAxis;
    //private bool isGrounded;

    [SerializeField] private float xForce; // movement speed;
    [SerializeField] private float yForce; // Jump Power;

    private CapsuleCollider2D _capsuleCollider2D;
    [SerializeField] private LayerMask canJump;

    //Player Animation//
    private Animator _animation;
    private SpriteRenderer _spriteRenderer;
    private static readonly int State = Animator.StringToHash("State");
    private enum CharacterState { Idle, Running, Jumping, Falling }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _animation = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        _xAxis = Input.GetAxisRaw("Horizontal");
        _yAxis = Input.GetAxisRaw("Vertical");

        //for horizontal movements (left and right)//
        _rigidbody2D.velocity = new Vector2(_xAxis * xForce,_rigidbody2D.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
        AnimState();
    }
    private void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, yForce);
    }
    private bool IsGrounded()
    {
        var bounds = _capsuleCollider2D.bounds;
        return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, 1f, canJump);

    }
    private void AnimState()
    { 
        CharacterState state;
        if (_xAxis > 0f)
        {
            state = CharacterState.Running;
            _spriteRenderer.flipX = false;
        }
        else if (_xAxis < 0f)
        {
            state = CharacterState.Running;
            _spriteRenderer.flipX = true;
        }
        else if(_rigidbody2D.velocity.y <-.1f)
        {
            state = CharacterState.Falling;
        }
        else if (_rigidbody2D.velocity.y > .1f)
        {
            state = CharacterState.Jumping;
        }
        else
        {
            state = CharacterState.Idle;
        }
        _animation.SetInteger(State,(int)state);
    }
}
