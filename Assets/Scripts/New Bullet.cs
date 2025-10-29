using UnityEngine;

public class NewBullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    public Vector2 click;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.linearVelocity = click * 5;

        Destroy(gameObject, 1);
    }
}
