using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_MoveablePlatform : Interactable
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float xMoveAmount;

    private Vector3 startPosition;
    private Vector3 endPosition;
    
    private bool isActive = false;

    private void Awake()
    {
        endPosition = transform.position + new Vector3(xMoveAmount, 0f, 0f);
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
