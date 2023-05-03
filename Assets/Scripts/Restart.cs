using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Text ScoreText;
    public Text HighScoreText;
    private float highscore;
    private float score;
    // Start is called before the first frame update
    void Start( )
    {
        highscore = PlayerPrefs.GetFloat("SCORE-");
        score = PlayerPrefs.GetFloat("HIGH SCORE-");

        ScoreText.text ="SCORE-" + score.ToString();
        HighScoreText.text ="HIGH SCORE-" + highscore.ToString();
    }

    public void Restartlevel()
    {
       SceneManager.LoadScene("Level1");
       Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
