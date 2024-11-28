using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField] private Interactable interactable;
    
    [SerializeField] private LayerMask layerMask; 
    private void OnTriggerEnter(Collider other)
    {
        interactable.StartInteract();
    }

    public void Interact()
    {
        interactable.StartInteract();
    }
}
