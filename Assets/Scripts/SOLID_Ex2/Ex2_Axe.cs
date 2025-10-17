using UnityEngine;

public class Ex2_Axe : MonoBehaviour
{
    [SerializeField] private int damage;
    private bool _canAttack = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Ex2_IDamageable>(out Ex2_IDamageable iDamage) && _canAttack)
        {
            iDamage.Hurt(damage);
            _canAttack = false;
            Invoke("CanAttackAgain", 2f);
        }
    }

    private void CanAttackAgain()
    {
        _canAttack = true;
    }
}
