using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _xAxis;
    private float _yAxis;
    private bool isHit;
    private bool isDead;
    private bool isAttacking;
    private bool isMoving;
    //private bool isGrounded;

    [SerializeField] private float xForce; // movement speed;
    [SerializeField] private float yForce; // Jump Power;

    private CapsuleCollider2D _capsuleCollider2D;
    [SerializeField] private LayerMask canJump;

    //Player Animation//
    private Animator _animation;
    private SpriteRenderer _spriteRenderer;
    private static readonly int State = Animator.StringToHash("State");
    private enum CharacterState { Idle, Running, Jumping, Falling, Hit, Death, Attack }

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
        if(!isAttacking)
        {
            //for horizontal movements (left and right)//
            _rigidbody2D.velocity = new Vector2(_xAxis * xForce, _rigidbody2D.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            if(!isAttacking)
            {
                Jump();
            }
        }
        AnimState();
        CheckAttack();
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
    private void CheckAttack()
    {
        //for stationary attack//
        if(Input.GetKeyDown (KeyCode.N) && !isAttacking && !isMoving)
        {
            Debug.Log("Player is attacking");
            isAttacking = true;
            StartCoroutine(AttackTime());
        }
    }
    private IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Attack done");
        isAttacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("hit");
            isHit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isHit = false;
    }
    private void AnimState()
    {
        CharacterState state;
        if (_xAxis > 0f)
        {
            state = CharacterState.Running;
            _spriteRenderer.flipX = false;
            isAttacking = false;
            isMoving = true;
           
        }
        else if (_xAxis < 0f)
        {
            state = CharacterState.Running;
            _spriteRenderer.flipX = true;
            isAttacking = false;
            isMoving = true;
        }
        else if(_rigidbody2D.velocity.y <-.1f)
        {
            state = CharacterState.Falling;
            isMoving = true;
        }
        else if (_rigidbody2D.velocity.y > .1f)
        {
            state = CharacterState.Jumping;
            isMoving = true;
        }
        else if (isHit)
        {
            state = CharacterState.Hit;
        }
        else if(isAttacking)
        {
            state = CharacterState.Attack;
        }
        else
        {
            state = CharacterState.Idle;
            isMoving = false;
        }
        _animation.SetInteger(State,(int)state);
    }
}
