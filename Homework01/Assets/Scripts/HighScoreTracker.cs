//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class HighScoreTracker
{
    
    public static void saveHighScore(float highScore)
    {

        if (highScore > loadScore())
        {

            string path = Application.persistentDataPath + "/playersHighScore.sc";


            BinaryFormatter bf = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Create);

            bf.Serialize(stream, highScore);

            stream.Close();

        }
        


    }

    public static float loadScore()
    {

        string path = Application.persistentDataPath + "/playersHighScore.sc";

        if (File.Exists(path)) 
        {
                
            BinaryFormatter bf = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            float highScore = (float)bf.Deserialize(stream);

            stream.Close();

            return highScore;
        
        
        
        }
        else
        {

            Debug.LogError("File not found in " +  path);
            return -1f;

        }



    }



}
