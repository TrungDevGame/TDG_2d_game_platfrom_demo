using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDemo : MonoBehaviour
{
    private float speed =4;
    bool isRight = true;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * xAxis * speed); //Move follow x
        float yAxis = Input.GetAxis("Vertical");      
        transform.Translate(Vector3.up * Time.deltaTime * yAxis * speed);

        if (xAxis != 0 || yAxis != 0)
        {
            animator.SetInteger("Move", 1);
        }
        else
        {
            animator.SetInteger("Move", 0);
        }
        if (xAxis > 0 && isRight == false)
        {
            Flip();
        }
        if (xAxis < 0 && isRight == true)
        {
            Flip();
        }
    }
    void Flip()
    {
        isRight = !isRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }

}
