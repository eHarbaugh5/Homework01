using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOEnemyMovement : MonoBehaviour
{
    private float movementSpeed;
    private bool moveRight;
    private bool isDisabled;
    // Start is called before the first frame update
    void Start()
    {
        moveRight = true;
        isDisabled = false;
        movementSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //  checks left and right positions
        if (transform.position.x <= -6)
        {
            moveRight = true;

        }
        else if (transform.position.x >= 5)
        {
            moveRight = false;
        }

        //  move left or right across screen
        if (moveRight)
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        else if (!moveRight)
        {

            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);

        }
    
        //  if disabled, leave upwards, if high enough, isdisabled=false and return down into position
        if (isDisabled)
        {

            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);

        }
        if (transform.position.y > 18)
        {
            isDisabled = false;
        }
        if (!isDisabled && transform.position.y > 3.47)
        {
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);

        }
       
    }

    public void disableUFO()
    {
        isDisabled = true;
        

    }


}
