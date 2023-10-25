using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Animations;
using UnityEngine;
//using UnityEngine.UIElements;

public class SpawnGround : MonoBehaviour
{
    private GameManager gameManagerScript;
    //  spawning related
    public GameObject[] spawnLocations;
    public GameObject[] groundPrefabs;
    public GameObject[] platformPrefabs;
    public GameObject[] collectablePrefabs;
    public GameObject[] enemyPrefabs;
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
        gameManagerScript = GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {

        checkGroundSpawn();

    }

    private void createFloor()
    {

        //  choses which ground style to spawn
        GameObject newFloor = Instantiate(groundPrefabs[Random.Range(0, 5)]);
        newFloor.transform.position = new Vector2(spawnLocations[0].transform.position.x, spawnLocations[0].transform.position.y);
        

        // chance of spawning a collectable
        if (Random.Range(0, 4) == 0)
        {

            GameObject newCollectable = Instantiate(collectablePrefabs[0]);
            newCollectable.transform.position = new Vector2(newFloor.transform.position.x, newFloor.transform.position.y + 1);

            newCollectable.transform.parent = newFloor.transform;

        }


    }

    private void createPlatform()
    {
        //  picks the level that the platform spawns on
        i = Random.Range(1, 3);
        //  choses which platform style to spawn
        GameObject newPlatform = Instantiate(platformPrefabs[Random.Range(0, 3)]);
        newPlatform.transform.position = new Vector2(spawnLocations[i].transform.position.x, spawnLocations[i].transform.position.y);


        //  decide to spawn an enemy/collectable/neither
        i = Random.Range(0, 10);
        // chance of spawning a collectable or a enemy
        if (i <= 2)
        {

            GameObject newCollectable = Instantiate(collectablePrefabs[0]);
            newCollectable.transform.position = new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y + 1);

            newCollectable.transform.parent = newPlatform.transform;

        }
        //  Enemy spawner
        //
        else if (i >= 3 && i <= 5) 
        {
            //enemyPrefabs[Random.Range(0, 0)]
            GameObject newEnemy = Instantiate(enemyPrefabs[Random.Range(0, 2)]);
            newEnemy.transform.position = new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y + 0.60f);

            newEnemy.transform.parent = newPlatform.transform;

        }
        else if (i > 8)
        {

            GameObject newCollectable = Instantiate(collectablePrefabs[Random.Range(1,4)]);
            newCollectable.transform.position = new Vector2(newPlatform.transform.position.x, newPlatform.transform.position.y + 1);

            newCollectable.transform.parent = newPlatform.transform;

        }



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

        //  platform 1 trigger
        if (groundTimer >= groundTimerInterval / 2 && canTimerTrigger1)
        {

            if (Random.Range(0,5) != 0)
            {
                createPlatform();
            }
            canTimerTrigger1 = false;

        }
        //  platform 2 trigger
        else if (groundTimer <= groundTimerInterval / 2 && canTimerTrigger2)
        {

            if (Random.Range(0, 6) != 0)
            {
                createPlatform();
            }
            canTimerTrigger2 = false;

        }
        

    }

    
    

}
