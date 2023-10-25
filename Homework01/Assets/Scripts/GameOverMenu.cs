using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public GameObject gameManager;
    public GameObject gameOverMenu;
    private GameManager gameManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.getGameOver() == true)
        {

            showGameOverMenu();
            

        }
    }

    public void showGameOverMenu()
    {

        gameOverMenu.SetActive(true);

    }

    public void exitGame()
    {

        SceneManager.LoadScene("MainMenu");

    }

    public void restartGame()
    {

        gameManagerScript.setGameOver(false);
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene("SampleScene");

    }

    


}
