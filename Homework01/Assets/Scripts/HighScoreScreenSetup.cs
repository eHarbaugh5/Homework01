using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreScreenSetup : MonoBehaviour
{
    public TMP_Text goldScore;
    public TMP_Text silverScore;
    public TMP_Text bronzeScore;
    public TMP_Text Score;
    public TMP_Text LastScore;
    void Start()
    {
        int[] currentScores = HighScoreTracker.loadScore();


        goldScore.text = (currentScores[0]).ToString();
        silverScore.text = (currentScores[1]).ToString();
        bronzeScore.text = (currentScores[2]).ToString();
        Score.text = (currentScores[3]).ToString();
        LastScore.text = (currentScores[4]).ToString();


    }

    




}
