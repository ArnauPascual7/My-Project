using UnityEngine;

public class NewSpawned : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    public GameObject NegativeLimit;
    public GameObject PositiveLimit;
    public NewSpawner spawner;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckPosition();

        OnMove();
    }

    private void CheckPosition()
    {
        Vector2 position = transform.position;
        float negativeLimitPosX = NegativeLimit.transform.position.x;
        float positiveLimitPosX = PositiveLimit.transform.position.x;

        if (transform.position.x <= negativeLimitPosX)
        {
            position.x = (float)(negativeLimitPosX + 0.1);
            position.y = position.y - 1;
            speed *= -1;
        }
        else if (transform.position.x >= positiveLimitPosX)
        {
            position.x = (float)(positiveLimitPosX - 0.1);
            position.y = position.y - 1;
            speed *= -1;
        }

        transform.position = position;

        if (transform.position.y <= -5)
        {
            //Destroy(gameObject);

            gameObject.SetActive(false);
            spawner.SpawnerStackPush(gameObject);
        }
    }

    private void OnMove()
    {
        _rb.linearVelocityX = speed;
    }
}
