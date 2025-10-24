using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MoveBehaviour))]
[RequireComponent(typeof(AnimationBehaviour))]
public class Cat : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions inputActions;
    private MoveBehaviour _mb;
    private AnimationBehaviour _ab;
    private float waitTime = 5f;
    private float idleTime;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);

        _mb = GetComponent<MoveBehaviour>();
        _ab = GetComponent<AnimationBehaviour>();

        idleTime = waitTime;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        if (_ab.idle && Time.time >= idleTime && idleTime != 0)
        {
            idleTime = 0;
            _ab.ExtraIdleAnimation();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();

        _mb.MoveCharacter(direction);
        _ab.RunAnimation(direction);

        if (context.canceled)
        {
            idleTime = Time.time + waitTime;
        }
    }
}
