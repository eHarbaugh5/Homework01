using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public TMP_Text scoreText;
    private float playerScore;


    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToScore(float s)
    {

        playerScore += s;
        scoreText.text = "Score: " + ((int)playerScore).ToString();
        

    }


}
