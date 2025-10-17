using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    public float jumpForce;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MoveCharacter(Vector2 direction)
    {
        _rb.linearVelocityX = direction.x * speed;
    }

    public void JumpCharacter()
    {
        _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
