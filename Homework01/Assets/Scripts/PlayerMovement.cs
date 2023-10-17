using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Device;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public GameObject gameManager;
    private GameManager gameManagerScript;
    private GameObject newParent;
    private float inputHorizontal;
    public float movementSpeed;
    public float jumpHeight;
    private bool canJump;

    public float decendSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        gameManagerScript = gameManager.GetComponent<GameManager>();
        canJump = true;
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
        
        //  unparent if you fall/move off a platform
        //  is ~0, but that triggers because of physics
        if (playerRigidBody.velocity.y < -1)
        {

            transform.parent = null;

        }


    }


    private void playerJump()
    {

        
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {

            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpHeight);
            canJump = false;
            transform.parent = null;

        }
        if (Input.GetKey(KeyCode.Space) && !canJump)
        {
            
            if (playerRigidBody.velocity.y <= -3)
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, -3);
                
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

            //  game over
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

            //prompt the main menu screen


        }




    }



}
