using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumper : MonoBehaviour
{
    private Rigidbody2D enemyRB;
    private GameObject newParent;
    private Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (enemyRB.velocity.y <= 1)
            {
                
                transform.parent = null;
                enemyRB.velocity = new Vector2(enemyRB.velocity.x, 12);
                enemyAnimator.SetBool("isJumping", true);

            }
        }

       
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            newParent = collision.gameObject;
            enemyRB.transform.parent = newParent.transform;
            enemyAnimator.SetBool("isJumping", false);

        }
    }

}
