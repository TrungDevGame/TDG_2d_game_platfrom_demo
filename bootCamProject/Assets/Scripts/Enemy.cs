using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 8;
    public Rigidbody2D rigidEnemy;
    public Vector2 direction;
    public GameObject player;
    void Start()
    {
        rigidEnemy = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        direction = player.transform.position - transform.position;
        if(transform.position.x>player.transform.position.x)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
        }

        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        rigidEnemy.velocity = direction.normalized *speed;
    }
}
