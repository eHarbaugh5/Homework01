using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScore;
    private float playerScore;


    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        scoreText.text = "Score: 0";
    
        
        highScore.text = "High Score: " + ((int)HighScoreTracker.loadScore()[0]).ToString();

        

    }


    public void addToScore(float s)
    {

        playerScore += s;
        scoreText.text = "Score: " + ((int)playerScore).ToString();
        

    }

    public float getScore()
    {

        return playerScore;

    }


}
