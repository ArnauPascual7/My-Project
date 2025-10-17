using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Ex2_Tree : MonoBehaviour, Ex2_IDamageable
{
    [SerializeField] private List<string> _items; // 0:Fulles, 1:Fusta, 2:Poma
    [SerializeField] private int MaxNumberOfDrops;
    private int CurrentDrops = 0;

    public void Hurt(int damage)
    {
        Drop();
    }

    public void Drop()
    {
        Debug.Log("Tree Dropped -> " + _items[0]);
        Debug.Log("Tree Dropped -> " + _items[1]);

        int rand = Random.Range(0, 4);

        if (rand == 0 && CurrentDrops <= MaxNumberOfDrops)
        {
            CurrentDrops++;
            Debug.Log("Tree Dropped -> " + _items[2]);
        }
    }
}
