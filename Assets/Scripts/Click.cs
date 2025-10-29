using UnityEngine;
using UnityEngine.InputSystem;

public class Click : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions inputActions;
    [SerializeField] private GameObject bullet;
    private Vector2 click =Vector2.zero;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            click = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());

            click = click.normalized;

            bullet.GetComponent<NewBullet>().click = click;

            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
    private void Update()
    {
        //Debug.Log(Mathf.Atan2(click.y, click.x));

        // -90 = Pi/2 Unity rotació per defecte
        // 360º / 2/Pi Conversió de radiats a graus
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, (Mathf.Atan2(click.y, click.x)-Mathf.PI/2f)*360f/2f/Mathf.PI));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
