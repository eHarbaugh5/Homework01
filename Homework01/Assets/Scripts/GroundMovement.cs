using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundMovement : MonoBehaviour
{
    private float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }
}
