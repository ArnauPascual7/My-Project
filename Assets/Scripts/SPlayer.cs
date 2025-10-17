using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MoveBehaviour))]
public class SPlayer : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private MoveBehaviour _mb;
    private InputSystem_Actions inputActions;
    private float floorLevel;

    private void Awake()
    {
        _mb = GetComponent<MoveBehaviour>();

        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);

        floorLevel = transform.position.y + 0.5f;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 direction = context.ReadValue<Vector2>();

            _mb.MoveCharacter(direction);
        }
        else if (context.canceled)
        {
            _mb.MoveCharacter(Vector2.zero);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && transform.position.y <= floorLevel)
        {
            _mb.JumpCharacter();
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
         
    }
}
