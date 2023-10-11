using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float inputHorizontal;
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    public float jumpHeight;
    private bool canJump;

    public float decendSpeed;

    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        playerRigidBody = GetComponent<Rigidbody2D>();
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
       

    }


    private void playerJump()
    {

        
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {

            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpHeight);
            canJump = false;

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
            canJump = true;
        }
    }

}
