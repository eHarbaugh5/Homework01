using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnGround : MonoBehaviour
{
    //  spawning related
    public GameObject[] spawnLocations;
    public GameObject[] groundPrefabs;
    public GameObject[] platformPrefabs;
    //  UI
    public TMP_Text scoreText;
    private ScoreTracker scoreTrackerScript;
    //  Timers and Pos Trackers
    private float groundTimer;
    public float groundTimerInterval;
    private int i;
    //  Switch Bools
    private bool canTimerTrigger1;
    private bool canTimerTrigger2;
    private bool skipedGroundSpawn;



    void Start()
    {
        createFloor();
        groundTimerInterval = 3.3f;
        groundTimer = groundTimerInterval;
        canTimerTrigger1 = true;
        canTimerTrigger2 = true;
        skipedGroundSpawn = false;
        scoreTrackerScript = scoreText.GetComponent<ScoreTracker>();
        
    }

    // Update is called once per frame
    void Update()
    {

        checkGroundSpawn();

    }

    private void createFloor()
    {

        GameObject newFloor = Instantiate(groundPrefabs[Random.Range(0, 7)]);
        newFloor.transform.position = new Vector2(spawnLocations[0].transform.position.x, spawnLocations[0].transform.position.y);
        

    }

    private void createPlatform()
    {

        i = Random.Range(1, 3);
        GameObject newPlatform = Instantiate(platformPrefabs[Random.Range(0, 8)]);
        newPlatform.transform.position = new Vector2(spawnLocations[i].transform.position.x, spawnLocations[i].transform.position.y);
        

    }

    private void checkGroundSpawn()
    {

        //  timer based on ground timer value
        groundTimer = groundTimer - Time.deltaTime;

        //  on 0, have a 1/6 chance of not spawning ground
        if (groundTimer <= 0)
        {
            
            if (Random.Range(0, 6) != 0 || skipedGroundSpawn == true)
            {
                
                createFloor();
                
                //  add score
                scoreTrackerScript.addToScore(0.5f);
                skipedGroundSpawn = false;
                
            }
            else
            {
                
                scoreTrackerScript.addToScore(1);
                skipedGroundSpawn = true;

            }
            groundTimer = groundTimerInterval;
            canTimerTrigger1 = true;
            canTimerTrigger2 = true;


        }

        if (groundTimer >= groundTimerInterval / 2 && canTimerTrigger1)
        {

            if (Random.Range(0,4) != 0)
            {
                createPlatform();
            }
            canTimerTrigger1 = false;

        }
        else if (groundTimer <= groundTimerInterval / 2 && canTimerTrigger2)
        {

            if (Random.Range(0, 4) != 0)
            {
                createPlatform();
            }
            canTimerTrigger2 = false;

        }
        

    }
    

}
