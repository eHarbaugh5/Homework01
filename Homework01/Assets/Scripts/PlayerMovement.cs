using System.Collections;
using System.Collections.Generic;
using TMPro;
//using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Device;
//using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public GameObject gameManager;
    private GameManager gameManagerScript;
    private GameObject newParent;
    public TMP_Text scoreTrackerText;
    private ScoreTracker scoreTrackerScript;
    private Animator playerAnimator;

    private float inputHorizontal;
    public float movementSpeed;
    public float jumpHeight;
    private bool canJump;

    public float decendSpeed;
    private bool FeatherPowerUp;
    private float featherTimer;

    // Start is called before the first frame update
    void Start()
    {
        //  remember to change the collider to match the new sprite
        playerRigidBody = GetComponent<Rigidbody2D>();
        gameManagerScript = gameManager.GetComponent<GameManager>();
        scoreTrackerScript = scoreTrackerText.GetComponent<ScoreTracker>();
        playerAnimator = GetComponent<Animator>();
        canJump = true;
        FeatherPowerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerJump();

        

    }

    private void playerMovement()
    {


        inputHorizontal = Input.GetAxisRaw("Horizontal");

        playerRigidBody.velocity = new Vector2(inputHorizontal * movementSpeed, playerRigidBody.velocity.y);

        if (inputHorizontal == 0)
        {
            playerAnimator.SetBool("isWalking", false);

        }
        else if (canJump && inputHorizontal != 0)
        {

            playerAnimator.SetBool("isWalking", true);

        }

        if (!canJump)
        {

            playerAnimator.SetBool("isJumping", true);

        }
        else
        {

            playerAnimator.SetBool("isJumping", false);

        }

        //  unparent if you fall/move off a platform
        //  is ~0, but that triggers because of physics
        if (playerRigidBody.velocity.y < -1)
        {

            transform.parent = null;

        }




    }


    private void playerJump()
    {

        if (FeatherPowerUp)
        {
            decendSpeed = 0;
        }
        else
        {
            decendSpeed = -3;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {

            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpHeight);
            canJump = false;
            transform.parent = null;

        }
        if (Input.GetKey(KeyCode.Space) && !canJump)
        {
            
            if (playerRigidBody.velocity.y <= decendSpeed)
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, decendSpeed);
                
            }


        }

        if (FeatherPowerUp)
        {

            featherTimer -= Time.deltaTime;
            if (featherTimer <= 0)
            {
                FeatherPowerUp = false;
            }

        }
        

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Ground"))
        {

            //  This but == 0, was resulting in odd numbers, while resting in the ground
            if (playerRigidBody.velocity.y >= -1 && playerRigidBody.velocity.y <= 1)
            {
                //  add parent with ground
                newParent = collision.gameObject;
                playerRigidBody.transform.parent = newParent.transform;
                //  allow jump
                canJump = true;
                
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            //  notify game manager that the game is over
            gameManagerScript.setGameOver(true);
        }

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("OB"))
        {

            //  tell game manager that you died
            gameManagerScript.setGameOver(true);

          
        }

        if (collision.gameObject.CompareTag("Collectable"))
        {
           //  add score based on the collectable value of the collision
            scoreTrackerScript.addToScore(collision.gameObject.GetComponent<Collectable>().getCollectableValue());
            //  destroy the gameobject that we copied with its script
            collision.gameObject.GetComponent<Collectable>().destroyCollectable();
            


        }

        if (collision.gameObject.CompareTag("CollectableDisable"))
        {

            gameManagerScript.disableUFO();

            collision.gameObject.GetComponent<Collectable>().destroyCollectable();

        }

        if (collision.gameObject.CompareTag("CollectableFeather"))
        {

            FeatherPowerUp = true;
            featherTimer = 7;

            collision.gameObject.GetComponent<Collectable>().destroyCollectable();

        }



    }


}
