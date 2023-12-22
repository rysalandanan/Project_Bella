using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //reference script//
    [Header("Player script (Movement)")]
    public PlayerMovement _pm;
    //
    private Animator _animator;
    public bool isDown;
    private static readonly int State = Animator.StringToHash("State");
    private enum CharacterState { Idle, Running, Death, Recharge, Attack}

    public GameObject Crosshair;
   
   
    void Start()
    {
        _animator = GetComponent<Animator>();
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
            state = CharacterState.Recharge;
            Crosshair.SetActive(true);
        }
        else if ( _pm._xAxis > 0f)
        {
            state = CharacterState.Running;
        }
        else if (_pm._xAxis < 0f)
        {
            state = CharacterState.Running;
        }
        else
        {
            state = CharacterState.Idle;
        }
        _animator.SetInteger(State,(int)state);
    }
}
