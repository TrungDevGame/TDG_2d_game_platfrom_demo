using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDemo : MonoBehaviour
{
    public Text txtMoney;
    public int money = 0;
    private float speed = 4;
    bool isRight = true;
    public Animator animator;
    public bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");

        float yAxis = Input.GetAxis("Vertical");
        if (!isAttack)
        {
            transform.Translate(Vector3.right * Time.deltaTime * xAxis * speed); //Move follow x
            transform.Translate(Vector3.up * Time.deltaTime * yAxis * speed);
        }

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttack = true;
            animator.SetTrigger("Attack");
        }
    }
    public void SetAttackFalse()
    {
        isAttack = false;
    }
    void Flip()
    {
        isRight = !isRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }
  
    public void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.gameObject.CompareTag("Coin"))
        {
            money = money + 100;
            Destroy(collision.gameObject);
            txtMoney.text = "Money :" + money.ToString();
        }

     
    }

}
