//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using System.Runtime.InteropServices.ComTypes;

public static class HighScoreTracker
{



    public static void saveHighScore(int highScore)
    {

        string[] highScoreSlots = new string[5];
        highScoreSlots[0] = "/playersHighScore0.sc";
        highScoreSlots[1] = "/playersHighScore1.sc";
        highScoreSlots[2] = "/playersHighScore2.sc";
        highScoreSlots[3] = "/playersHighScore3.sc";
        highScoreSlots[4] = "/playersHighScore4.sc";

       
        int[] currentHighScores = loadScore();

        //  if high score is greater than the lowest score
        if (highScore > currentHighScores[4])      
        {


            //  arrange

            //  start with greatest value, and go to lowest
            for (int i = 0; i < currentHighScores.Length; i++)
            {
                if (highScore > currentHighScores[i])
                {
                    //  get copy
                    int temp = currentHighScores[i];
                    //  set to greater value
                    currentHighScores[i] = highScore;
                    //  reset to check with old value
                    highScore = temp;


                }

            }

            //  store

            string path;



            for (int i = 0; i < 5; i++)
            {
                path = Application.persistentDataPath + highScoreSlots[i];


                BinaryFormatter bf = new BinaryFormatter();

                FileStream stream = new FileStream(path, FileMode.Create);

                bf.Serialize(stream, currentHighScores[i]);

                stream.Close();
            }

            

            //  ------------------------------------------------------------------------



        }

    }


    public static int[] loadScore()
    {

        string[] highScoreSlots = new string[5];
        highScoreSlots[0] = "/playersHighScore0.sc";
        highScoreSlots[1] = "/playersHighScore1.sc";
        highScoreSlots[2] = "/playersHighScore2.sc";
        highScoreSlots[3] = "/playersHighScore3.sc";
        highScoreSlots[4] = "/playersHighScore4.sc";

        string path = Application.persistentDataPath + "/playersHighScore4.sc";

        if (File.Exists(path))
        {

            int[] topScores = new int[5];

            for (int i = 0; i < 5; i++)
            {
                path = Application.persistentDataPath + highScoreSlots[i];

                BinaryFormatter bf = new BinaryFormatter();

                FileStream stream = new FileStream(path, FileMode.Open);

                int score = (int)bf.Deserialize(stream);

                topScores[i] = score;

                stream.Close();
            }

            return topScores;
        }
        else
        {
            int[] errorScores = new int[5];
            for (int i = 0; i < 5; i++)
            {
                errorScores[i] = 0;
            }

                Debug.LogError("File not found in " + path);
            return errorScores;
        }
    }


}
