using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int totalCollected = 0;
    
    public static InventoryManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        totalCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int addTotalCollected()
    {
        return totalCollected++;
    }
}
