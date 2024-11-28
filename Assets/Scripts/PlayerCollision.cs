using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        PressButton potentialButton = other.gameObject.GetComponentInParent<PressButton>();
        if (potentialButton != null)
        {
            potentialButton.Interact();
        }
    }
}
