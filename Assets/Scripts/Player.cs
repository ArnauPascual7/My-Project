using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions inputActions;
    private Rigidbody2D _rb;
    private Transform _shootPoint;
    private float timeBetweenBullets = 0.5f;
    private float nextBulletTime = 0.5f;
    [SerializeField] private GameObject bullet;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
        _shootPoint = GetComponentInChildren<Transform>().GetChild(0);
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
        _rb.linearVelocity = context.ReadValue<Vector2>() * 10;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (Time.time >= nextBulletTime)
            {
                Instantiate(bullet, _shootPoint.position, Quaternion.identity);
                nextBulletTime = Time.time + timeBetweenBullets;
            }
        }
    }
}
