using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    
    private float collectableValue;
    // Start is called before the first frame update
    void Start()
    {
        collectableValue = 1f;
       
    }

    public float getCollectableValue()
    {
        return collectableValue;
    }

    public void destroyCollectable()
    {
        Debug.Log("Destroy this.object");
        Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        

    }
    //  perminant hover
    //  disable mothership
    //  gold rush


}
