using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //reference script//
    public PlayerMovement _playerManager;
    //
    private Animator _animator;
    private bool isDown;
    private SpriteRenderer _spriteRenderer;
   
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if(!isDown)
        {
            if (_playerManager._xAxis > 0f)
            {
                _animator.Play("Player Movement");
                _spriteRenderer.flipX = false;
            }
            else if (_playerManager._xAxis < 0f)
            {
                _animator.Play("Player Movement");
                _spriteRenderer.flipX = true;
            }
            else if (_playerManager._rigidbody2D.velocity.y > 1f)
            {
                _animator.Play("Player Jumping");

            }
            else if (_playerManager._rigidbody2D.velocity.y < -1f)
            {
                _animator.Play("Player Falling");
            }
            else
            {
                _animator.Play("Player Idle");
            }
        }
    }
    public void PlayerDownAnimation()
    {
        _animator.Play("Player Down");
        isDown = true;
    }
    public void PlayerRevived()
    {
        isDown = false;
    }
}
