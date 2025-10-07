using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float timeBetweenEnemies = 2f;
    [SerializeField] private GameObject enemy;
    private Stack<GameObject> EnemiesStack = new Stack<GameObject>();

    /*private Color[] enemyColors =
    {
        Color.blue,
        Color.green,
        Color.red,
        Color.yellow
    };*/

    private void Update()
    {
        if (Time.time >= timeBetweenEnemies)
        {
            //enemy.GetComponent<SpriteRenderer>().color = enemyColors[Random.Range(0, 3)];

            if (EnemiesStack.Count == 0)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
            }
            else
            {
                EnenmyStackPop();
            }
            
            timeBetweenEnemies += 2f;
        }
    }

    public void EnemyStackPush(GameObject go)
    {
        EnemiesStack.Push(go);
        go.SetActive(false);
    }

    public GameObject EnenmyStackPop()
    {
        GameObject go = EnemiesStack.Pop();

        go.SetActive(true);
        go.transform.position = transform.position;

        return go;
    }
}
