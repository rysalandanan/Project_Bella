using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //reference script//
    [Header("Player script (Movement)")]
    public PlayerMovement _pm;
    //
    private Animator _animator;
    public bool isDown;
    private SpriteRenderer _spriteRenderer;
    private static readonly int State = Animator.StringToHash("State");
    private enum CharacterState { Idle, Running, Jumping, Falling, Down, Recharge, Attack}
   
   
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        CharacterState state;
        if (isDown)
        {
            state = CharacterState.Down;
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            state = CharacterState.Recharge;
        }
        else if(Input.GetKeyDown(KeyCode.N))
        {
            state = CharacterState.Attack;
        }
        else if ( _pm._xAxis > 0f)
        {
            _spriteRenderer.flipX = false;
            state = CharacterState.Running;
        }
        else if (_pm._xAxis < 0f)
        {
            _spriteRenderer.flipX = true;
            state = CharacterState.Running;
        }
        else if (_pm._yAxis> .1f)
        {
            state = CharacterState.Jumping;
        }
        else if (_pm._yAxis < -.1f)
        {
            state = CharacterState.Falling;
        }
        else
        {
            state = CharacterState.Idle;
        }
        _animator.SetInteger(State,(int)state);
    }
}
