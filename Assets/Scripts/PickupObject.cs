using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    InventoryManager inventoryManager;
    
    private void Start()
    {
        inventoryManager = InventoryManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inventoryManager.addTotalCollected();
            Debug.Log(inventoryManager.totalCollected);
            Destroy(this.gameObject);
        }
    }
}
