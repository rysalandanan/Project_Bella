using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _xAxis;
    private float _yAxis;
    private bool isHit;
    private bool isDown;
    private bool isAttacking;
    private bool isMoving;

    [SerializeField] private float xForce; // movement speed;
    [SerializeField] private float yForce; // Jump Power;

    private CapsuleCollider2D _capsuleCollider2D;
    [SerializeField] private LayerMask canJump;

    //Player Animation//
    private Animator _animation;
    private SpriteRenderer _spriteRenderer;
    private static readonly int State = Animator.StringToHash("State");
    private enum CharacterState { Idle, Running, Jumping, Falling, Hit, Down, Attack }


    public GameSettings _gameSettings;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _animation = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
       
    }
    private void FixedUpdate()
    {
        if(_gameSettings.isInputEnabled)
        {
            _xAxis = Input.GetAxisRaw("Horizontal");
            _yAxis = Input.GetAxisRaw("Vertical");
            if (!isAttacking) // CHECKING IF PLAYER IS NOT ATTACKING//
            {
                //for horizontal movements (left and right)//
                _rigidbody2D.velocity = new Vector2(_xAxis * xForce, _rigidbody2D.velocity.y);
            }
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) // CHECKING IF PLAYER IS GROUNDED//
            {
                if (!isAttacking) // CHECKING IF PLAYER IS NOT ATTACKING//
                {
                    Jump();
                }
            }
            CheckAttack(); // CHECKING IF PLAYER ATTACKS//
        }
        AnimationUpdateState(); // PLAYER ANIMATION UPDATE//
    }
    private bool IsGrounded() // CHECKING IF PLAYER IS GROUNDED//
    {
        var bounds = _capsuleCollider2D.bounds; // COLLIDER FOR GROUND CHECK//
        return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, 1f, canJump);
        // COLLIDER SETTINGS//

    }
    private void Jump() // PLAYER JUMP//
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, yForce);
    }
    private void CheckAttack() //CHECK IF PLAYER ATTACK//
    {
        //STATIONARY ATTACK//
        if(Input.GetKeyDown (KeyCode.N) && !isAttacking && !isMoving)
        {
            isAttacking = true; // STARTS ATTACKING//
            StartCoroutine(AttackTime());
        }
     
    }
    private IEnumerator AttackTime() //ATTACK TIMER//
    {
        yield return new WaitForSeconds(1); //ATTACK HAS 1 SECOND  DURATION//
        Debug.Log("Attack done");
        isAttacking = false; // NO LONGER ATTACKING//
    }
    public void PlayerDown()
    {
        isDown = true;
    }
    public void PlayerRevived()
    {
        isDown = false;
    }
       
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            isHit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isHit = false;
    }

    //ANIMATIONS//
    private void AnimationUpdateState()
    {
        CharacterState state;
        if (_xAxis > 0f) // CHECKING IF PLAYER IS MOVING RIGHT //
        {
            state = CharacterState.Running;
            _spriteRenderer.flipX = false;
            isAttacking = false;
            isMoving = true;
            Debug.Log("running");
        }
        else if (_xAxis < 0f) // CHECKING IF PLAYER IS MOVING LEFT //
        {
            state = CharacterState.Running;
            _spriteRenderer.flipX = true;
            isAttacking = false;
            isMoving = true;
            Debug.Log("running");
        }
        else if (_rigidbody2D.velocity.y < -.1f) // CHECKING IF PLAYER IS FALLING //
        {
            state = CharacterState.Falling;
            isMoving = true;
        }
        else if (_rigidbody2D.velocity.y > .1f) // CHECKING IF PLAYER IS JUMPING //
        {
            state = CharacterState.Jumping;
            isMoving = true;
        }
        else if (isHit && !isDown) //CHECKING IF PLAYER GOT HIT //
        {
            state = CharacterState.Hit;
            Debug.Log("hit");
        }
        else if (isAttacking) // CHECKING IF PLAYER IS ATTACKING //
        {
            state = CharacterState.Attack;
            Debug.Log("Attacking");
        }
        else if(isDown) // CHECKING IF PLAYER IS DOWN //
        {
            state = CharacterState.Down;
            Debug.Log("down");
        }
        else // CHECKING IF PLAYER IS NOT DOING ANYTHING //
        {
            state = CharacterState.Idle;
            isMoving = false;
        }
        _animation.SetInteger(State, (int)state);
    }
}
