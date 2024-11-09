using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedChecker : MonoBehaviour
{
    private const float radius = 0.2f;
    
    [SerializeField] private LayerMask GroundLayer;
    
    public bool IsGrounded;

    // Events
    public event Action OnBecameGrounded;
    public event Action OnBecameAirborne;
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        bool wasGrounded = IsGrounded;
        IsGrounded = Physics.OverlapSphere(transform.position, radius, GroundLayer).Length > 0;

        if (!wasGrounded && IsGrounded)
        {
            OnBecameGrounded?.Invoke();
        }

        if (wasGrounded && !IsGrounded)
        {
            OnBecameAirborne?.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        Gizmos.color = IsGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
