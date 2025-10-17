using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private string Name;
    private string Efect;
    private int Quantity;

    protected void Use()
    {
        Debug.Log(Efect);
    }
}
