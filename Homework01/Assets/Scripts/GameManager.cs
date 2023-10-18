using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    private bool gameisOver;
    public GameObject scoreText;
    private ScoreTracker scoreTrackerScript;
    // Start is called before the first frame update
    void Start()
    {
        setGameOver(false);
        scoreTrackerScript = scoreText.GetComponent<ScoreTracker>();

        //  add a high score Canvas element and give it the high score
        //Debug.Log("High Score: " + HighScoreTracker.loadScore());

    }

    public bool getGameOver()
    {

        return gameisOver;

    }

    public void setGameOver(bool g)
    {
        
        gameisOver = g;
        evaluateGameState();


    }

    public void evaluateGameState()
    {
        
        if (gameisOver)
        {
            
            HighScoreTracker.saveHighScore(scoreTrackerScript.getScore());
            Time.timeScale = 0f;

        }
        else
        {
            Time.timeScale = 1f;

        }

    }


}
