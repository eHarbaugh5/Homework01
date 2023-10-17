using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOEnemyMovement : MonoBehaviour
{
    private float movementSpeed;
    private bool moveRight;
    // Start is called before the first frame update
    void Start()
    {
        moveRight = true;
        movementSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x <= -6)
        {
            moveRight = true;

        }
        else if (transform.position.x >= 5)
        {
            moveRight = false;
        }


        if (moveRight)
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        else if (!moveRight)
        {

            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);

        }
    

       
    }
}
