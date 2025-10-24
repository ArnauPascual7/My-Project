using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class AnimationBehaviour : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sr;
    public bool idle;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();

        idle = _animator.GetFloat("Velocity") == 0;
    }

    public void RunAnimation(Vector2 direction)
    {
        _animator.SetBool("Lick", false);
        _animator.SetBool("Strech", false);

        if (direction.x < 0)
        {
            _sr.flipX = true;
        }
        else if (direction.x > 0)
        {
            _sr.flipX = false;
        }
        
        _animator.SetFloat("Velocity", direction.magnitude);

        idle = _animator.GetFloat("Velocity") == 0;
    }

    public void ExtraIdleAnimation()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            _animator.SetBool("Lick", true);
        }
        else if (rand == 1)
        {
            _animator.SetBool("Strech", true);
        }
    }
}
