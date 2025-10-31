using System.Collections.Generic;
using UnityEngine;

public class NewSpawner : MonoBehaviour
{
    public GameObject spawned;
    public float spawnInterval = 2.0f;
    private float timer;

    [SerializeField] private GameObject SpawnedNegativeLimit;
    [SerializeField] private GameObject SpawnedPositiveLimit;

    public Stack<GameObject> SpawnedStack = new Stack<GameObject>();

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            if (SpawnedStack.Count == 0)
            {
                SpawnObject();
            }
            else
            {
                SpawnerStackPop();
            }

            timer = 0f;
        }
    }

    private void SpawnObject()
    {
        spawned.GetComponent<NewSpawned>().spawner = this;

        spawned.GetComponent<NewSpawned>().speed = 5f;

        spawned.GetComponent<NewSpawned>().NegativeLimit = SpawnedNegativeLimit;
        spawned.GetComponent<NewSpawned>().PositiveLimit = SpawnedPositiveLimit;

        Instantiate(spawned, transform.position, transform.rotation);
    }

    public void SpawnerStackPush(GameObject go)
    {
        SpawnedStack.Push(go);
        go.SetActive(false);
    }

    private void SpawnerStackPop()
    {
        GameObject go = SpawnedStack.Pop();

        go.SetActive(true);

        go.transform.position = transform.position;
        go.transform.rotation = Quaternion.identity;

        go.GetComponent<NewSpawned>().speed = 5f;

        //return go;
    }
}
