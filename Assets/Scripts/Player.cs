using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Touch touch;
    public float speed;
    public float speedcontroller;
    public Text ScoreText;
    public Text Score2Text;
    public float score;
    public GameObject gameoverpannel;
    public bool isGameover;

    private void Awake() 
    {
        isGameover=false;
        score = 0;
        if (PlayerPrefs.GetFloat("HIGH SCORE-")==0)
        {
            PlayerPrefs.SetFloat("HIGH SCORE-",0);
        }

        PlayerPrefs.SetFloat("Score",score);
    }
    void Start()
    {
        
        speedcontroller = 0.01f;
    }

    // Update is called once per frame
    void Update()

    {
        if(isGameover == false)
        {
            score++;
        }
        
        ScoreText.text = "SCORE-" + score;
        Score2Text.text = "SCORE-" + score;
        
        if (Input.GetKey(KeyCode.LeftArrow)&& transform.position.x>-4f)
        {
            transform.Translate(Vector3.left * speed *Time.deltaTime);
        }

         if (Input.GetKey(KeyCode.RightArrow)&& transform.position.x < +4f)
        {
            transform.Translate(Vector3.right * speed *Time.deltaTime);
        }

        transform.Translate(Vector3.forward * speed *Time.deltaTime);

        if (Input.touchCount > 0 && transform.position.x>=-4f && transform.position.x <= +4f)
        {
          touch = Input.GetTouch(0);
            transform.Translate(touch.deltaPosition.x * speedcontroller,0,0);
        }
        else if(transform.position.x>4f)
        {
            transform.position = new Vector3(4f,transform.position.y,transform.position.z);
        }
         
         else if(transform.position.x<-4f)
        {
            transform.position = new Vector3(-4f,transform.position.y,transform.position.z);
        }
         
         }

         private void OnTriggerEnter(Collider other) 
         {
            if(other.gameObject.tag == "Enemy")
            {
                isGameover=true;
                Debug.Log("oops");
                gameoverpannel.SetActive(true);
                Time.timeScale = 0f;
            }
            if (PlayerPrefs.GetFloat("HIGH SCORE-")<score)
            {
                PlayerPrefs.SetFloat("HIGH SCORE-",score);
                PlayerPrefs.SetFloat("SCORE-",score);
            }

            else
            {
                PlayerPrefs.SetFloat("SCORE-",score);
            }
         }
}
