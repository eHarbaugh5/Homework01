using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void startGame()
    {

        SceneManager.LoadScene("SampleScene");

    }

    public void highScoreScreen()
    {

        SceneManager.LoadScene("HighScore");

    }

    public void exitGame()
    {

        Application.Quit();

    }


}
