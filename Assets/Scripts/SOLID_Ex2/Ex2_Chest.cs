using UnityEngine;

public class Ex2_Chest : MonoBehaviour, Ex2_IDamageable
{
    [SerializeField] private string Drop;

    public void Hurt(int damage)
    {
        Open();
    }

    public void Open()
    {
        Debug.Log("Chest was Opened and Dropped -> " + Drop);
    }
}
