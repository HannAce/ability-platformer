using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Light : Interactable
{
    [SerializeField] private Light spotLight;

    private void Awake()
    {
        spotLight.enabled = false;
    }

    public override void StartInteract()
    {
        spotLight.enabled = !spotLight.enabled;
    }

    public override void StopInteract()
    {
        
    }
}
