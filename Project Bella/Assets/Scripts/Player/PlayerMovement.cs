using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    public float _xAxis;
    private float _yAxis;
    
    //Coyote time//
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    //Jump buffer//
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    //Flip//
    private bool isFacingRight = true;

    //Trail Renderer
    private TrailRenderer _trailRenderer;

    //Dash//
    [Header("Dash settings")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashCoolDown = 1f;
    [SerializeField] bool canDash;

    [SerializeField] private float xForce; 
    [SerializeField] private float yForce; 

    private CapsuleCollider2D _capsuleCollider2D;
    [SerializeField] private LayerMask canJump;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
        canDash = true;
    }
    private void Update()
    {
        if(IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, yForce);
            jumpBufferCounter = 0f;
        }
        if(Input.GetButtonUp("Jump") && _rb2D.velocity.y > 0f) 
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _rb2D.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
    }
    private void FixedUpdate()
    {
        _xAxis = Input.GetAxisRaw("Horizontal");
        _yAxis = Input.GetAxisRaw("Vertical");
        _rb2D.velocity = new Vector2(_xAxis * xForce, _rb2D.velocity.y);
        if(_xAxis < 0 && isFacingRight)
        {
            flip();
        }
        if (_xAxis > 0 && !isFacingRight)
        {
            flip();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(PlayerDash());
        }
    }
    private bool IsGrounded()
    {
       var bounds = _capsuleCollider2D.bounds;
       return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, 0.2f, canJump);
    }
    private void flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);  
    }
    private IEnumerator PlayerDash()
    {
        _trailRenderer.emitting = true;
        canDash = false;
        _rb2D.velocity = new Vector2(_xAxis * dashSpeed, _yAxis * dashSpeed);
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
        _trailRenderer.emitting = false;
    }
}
