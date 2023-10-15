using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnGround : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject groundPrefab;
    public GameObject platformPrefab;
    private float groundTimer;
    public float groundTimerInterval;
    private int groundPos;

    private bool canTimerTrigger1;
    private bool canTimerTrigger2;
    // Start is called before the first frame update
    void Start()
    {
        createFloor();
        groundTimerInterval = 3.3f;
        groundTimer = groundTimerInterval;
        groundPos = 0;
        canTimerTrigger1 = true;
        canTimerTrigger2 = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        checkGroundSpawn();

    }

    private void createFloor()
    {

        GameObject newFloor = Instantiate(groundPrefab);
        newFloor.transform.position = new Vector2(spawnLocations[0].transform.position.x, spawnLocations[0].transform.position.y);
        

    }

    private void createPlatform()
    {

        GameObject newPlatform = Instantiate(platformPrefab);
        newPlatform.transform.position = new Vector2(spawnLocations[groundPos].transform.position.x, spawnLocations[groundPos].transform.position.y);
        groundPos++;
        if (groundPos == spawnLocations.Length || groundPos == 0)
        {
            groundPos = 1;
        }

    }

    private void checkGroundSpawn()
    {

        //  timer based on ground timer value
        groundTimer = groundTimer - Time.deltaTime;

        //  on 0, have a 1/6 chance of not spawning ground
        if (groundTimer <= 0)
        {
            
            if (Random.Range(0, 6) != 0)
            {
                
                createFloor();

            }
            groundTimer = groundTimerInterval;
            canTimerTrigger1 = true;
            canTimerTrigger2 = true;


        }
        if (groundTimer >= groundTimerInterval / 2 && canTimerTrigger1)
        {

            createPlatform();
            canTimerTrigger1 = false;

        }
        if (groundTimer >= groundTimerInterval % 2 && canTimerTrigger2)
        {
            createPlatform();
            canTimerTrigger2 = false;
        }



        //  spawn 2 platforms alternating


    }
    

}
