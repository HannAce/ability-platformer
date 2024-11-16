using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private int totalCollected = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            totalCollected++;
            Debug.Log("Total items collected: " + totalCollected);
            Destroy(this.gameObject);
        }
    }
}
