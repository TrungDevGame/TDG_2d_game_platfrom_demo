using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Rigidbody2D ghostRigidbody;
    public Vector3 direction;
    public GameObject player;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        ghostRigidbody = GetComponent<Rigidbody2D>();
        direction = player.transform.position - transform.position;
        Destroy(this.gameObject, 5f);
        if(transform.position.x>player.transform.position.x)
        {
            Flip();
        }
    }
    void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
    }
    // Update is called once per frame
    void Update()
    {
        ghostRigidbody.velocity = direction.normalized* speed;

    }
}
