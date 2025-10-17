using UnityEngine;
[RequireComponent(typeof(MoveBehaviour))]
public class Ex1_Enemy : MonoBehaviour
{
    private MoveBehaviour _mb;
    private Vector2 _direction;
    [SerializeField] private GameObject LimitPos;
    [SerializeField] private GameObject LimitNeg;
    private int waitTime = 0;

    private void Awake()
    {
        _mb = GetComponent<MoveBehaviour>();
        _direction = Vector2.right;

        SetWaitTime();
    }

    private void Update()
    {
        _mb.MoveCharacter(_direction);

        if (transform.position.x >= LimitPos.transform.position.x)
        {
            _direction = Vector2.left;
        }
        else if (transform.position.x <= LimitNeg.transform.position.x)
        {
            _direction = Vector2.right;
        }

        if (Time.time >= waitTime)
        {
            _mb.JumpCharacter();

            SetWaitTime();
        }
    }

    private void SetWaitTime()
    {
        int random = Random.Range(1, 3);
        waitTime += random;
    }
}
