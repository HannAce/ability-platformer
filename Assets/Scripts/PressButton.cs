using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField] private Interactable interactable;
    
    [SerializeField] private LayerMask layerMask; 
    private void OnCollisionEnter(Collision other)
    {
        // Move player Layer into a manager at some point
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            interactable.StartInteract();
        }
    }
}
