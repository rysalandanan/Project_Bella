using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D _rigidbody2D;
    public float _xAxis;
    public float _yAxis;
    private bool isAttacking;
    private bool isMoving;

    [SerializeField] private float xForce; // movement speed;
    [SerializeField] private float yForce; // Jump Power;

    private CapsuleCollider2D _capsuleCollider2D;// for ground check;
    [SerializeField] private LayerMask canJump;

    public GameObject downScreen;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    private void FixedUpdate()
    {
        if(!downScreen.activeInHierarchy)
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
}
