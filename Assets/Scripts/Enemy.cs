using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _enemyLimitPositionsLeft;
    private float _enemyLimitPositionsRight;
    private float speed;
    public EnemySpawner spawner;
    private GameObject textGameOver;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyLimitPositionsLeft = -9;
        _enemyLimitPositionsRight = 9;
        speed = 5f;
        GameObject canvas = GameObject.Find("Canvas");
    }

    private void Update()
    {
        Transform transform = GetComponent<Transform>();

        //CheckBulletsPosition(transform);

        CheckPosition(transform);

        OnMove(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // BulletPlayer Collision
        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);

            spawner.EnemyStackPush(gameObject);

            //Destroy(gameObject);
        }
        
        // Player Collision
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);

            //textGameOver.SetActive(true);
        }
    }

    /*private void CheckBulletsPosition(Transform transform)
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        foreach (GameObject bullet in bullets)
        {
            Transform bulletTransform = bullet.transform;

            if (transform.position.y >= bulletTransform.position.y - 0.5 && transform.position.y <= bulletTransform.position.y + 0.5)
            {
                if (transform.position.x >= bulletTransform.position.x - 0.5 && transform.position.x <= bulletTransform.position.x + 0.5)
                {
                    //gameObject.SetActive(false);
                    Destroy(gameObject);
                }
            }
        }
    }*/

    private void CheckPosition(Transform transform)
    {
        Vector2 position = transform.position;

        if (transform.position.x <= _enemyLimitPositionsLeft)
        {
            position.x = (float)(_enemyLimitPositionsLeft + 0.1);
            position.y = position.y - 1;
            speed *= -1;
        }
        else if (transform.position.x >= _enemyLimitPositionsRight)
        {
            position.x = (float)(_enemyLimitPositionsRight - 0.1);
            position.y = position.y - 1;
            speed *= -1;
        }
        
        transform.position = position;

        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnMove(float speed)
    {
        _rb.linearVelocityX = speed;
    }
}
