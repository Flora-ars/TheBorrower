using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionCounter : MonoBehaviour
{
    private int counter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Collector.itemCollect))
        {
            Destroy(other.gameObject);
            counter++;

            Debug.Log(counter);
        }
    }
        
    
}
