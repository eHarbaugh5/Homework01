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
        
        Destroy(this.gameObject);

    }




}
