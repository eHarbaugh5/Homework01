using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    private bool gameisOver;
    // Start is called before the first frame update
    void Start()
    {
        setGameOver(false);
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

            Time.timeScale = 0f;

        }
        else
        {

            Time.timeScale = 1f;

        }

    }


}
