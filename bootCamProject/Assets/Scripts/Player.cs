using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    public float speed = 1;
    public int money = 0;
    public Text txtMoney;
    bool isRight=true;
    public Animator animator;
    public bool isDie;
    AudioSource audioPlayer;
    public AudioClip coinSound;
    public GameObject gameOver;
    public float timeCount = 60;
    public TextMeshProUGUI txtTimeCount;
    public GameObject youWin;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDie)
        {
            return;
        }
        timeCount -= Time.deltaTime;
        float xAxis = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * xAxis * speed); //Move follow x
        float yAxis = Input.GetAxis("Vertical");
        //Debug.Log(yAxis);
        transform.Translate(Vector3.up * Time.deltaTime * yAxis * speed); //Move follow x

        if(xAxis>0 && isRight==false)
        {
            Flip();
        }  
        if(xAxis<0 && isRight==true)
        {
            Flip();
        }   
        if(xAxis!=0 || yAxis!=0)
        {
            animator.SetInteger("Move", 1);
        }else
        {
            animator.SetInteger("Move", 0);
        }
        txtTimeCount.text = "Time : "+((int)timeCount).ToString();
        if(timeCount<0)
        {
            youWin.SetActive(true);
        }

    }
    void Flip()
    {
        isRight = !isRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }    
 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDie)
        {
            return;
        }
        //kiêm tra lượm coin
        if (collision.gameObject.CompareTag("Coin"))
        {
            money = money + 100;
            Destroy(collision.gameObject);
            txtMoney.text = "Money :" + money.ToString();
            audioPlayer.PlayOneShot(coinSound);
        }

        //kiểm tra con ma chạm vào người
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // bật animation die và kết thúc game
            animator.SetTrigger("TriggerDie");
            isDie = true;
            StartCoroutine(ShowGameOver());
        }
    }
    
    IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(0.5f);
        gameOver.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
