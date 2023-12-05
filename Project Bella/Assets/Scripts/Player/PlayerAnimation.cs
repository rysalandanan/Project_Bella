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
    private enum CharacterState { Idle, Running, Death, Recharge, Attack}
   
   
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
            state = CharacterState.Death;
        }
        else if(Input.GetKey(KeyCode.E))
        {
            Debug.Log("z");
            state = CharacterState.Recharge;
        }
        else if(Input.GetKey(KeyCode.N))
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
        else
        {
            state = CharacterState.Idle;
        }
        _animator.SetInteger(State,(int)state);
    }
}
