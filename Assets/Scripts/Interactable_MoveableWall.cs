using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactable_MoveableWall : Interactable
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float yMoveAmount;

    private Vector3 endPosition;

    
    private bool isActive = false;

    private void Awake()
    {
        endPosition = transform.position + new Vector3(0f, yMoveAmount, 0f);
    }

    private void FixedUpdate()
    {
        if (!isActive)
        {
            return;
        }
        
        transform.position = Vector3.Lerp(transform.position, endPosition, Time.fixedDeltaTime * moveSpeed); 
    }

    [ContextMenu("Activate")]
    public override void StartInteract()
    {
        isActive = true;
    }

    public override void StopInteract()
    {
        isActive = false;
    }
}
