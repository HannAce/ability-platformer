using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPlayerMovement : MonoBehaviour
{
    [SerializeField] private GameplayConfig gameplayConfig;
    
    [SerializeField] private Rigidbody rb;
    
    [SerializeField] private GroundedChecker groundedChecker;
    
    private Vector3 playerMovement;
    private float remainingJumpForce;

    private bool canSlam = true;
    
    private float MovementAcceleration => gameplayConfig.MovementAcceleration;
    private float MaxMovementSpeed => gameplayConfig.MaxMovementSpeed;
    private float MovementDamping => gameplayConfig.MovementDamping;
    
    private float JumpStrength => gameplayConfig.JumpStrength;
    private float SlamStrength => gameplayConfig.SlamStrength;

    // Start is called before the first frame update
    private void Start()
    {
        if (gameplayConfig == null)
        {
            Debug.LogError("PhysicsPlayerMovement is missing gameplay config reference!");
        }
        if (groundedChecker == null)
        {
            Debug.LogError("PhysicsPlayerMovement is missing grounded checker reference!");
        }
        
        groundedChecker.OnBecameGrounded += HandleBecameGrounded;
    }
    
    private void OnDestroy()
    {
        groundedChecker.OnBecameGrounded -= HandleBecameGrounded;
    }

    // Update is called once per frame
    private void Update()
    {
        GetMovementInput();
    }

    private void FixedUpdate()
    {
        MovementForceAndClamping();
    }
    
    private void HandleBecameGrounded()
    {
        canSlam = true;
    }

    private void GetMovementInput()
    {
        playerMovement = default; // start at default 0 value

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerMovement += Vector3.left * MovementAcceleration;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playerMovement += Vector3.right * MovementAcceleration;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJumpOrGroundSlam();
        }
    }

    private void MovementForceAndClamping()
    {
        rb.AddForce(playerMovement, ForceMode.Impulse);

        if (remainingJumpForce != 0)
        {
            rb.AddForce(Vector3.up * remainingJumpForce, ForceMode.Impulse);
            remainingJumpForce = 0;
        }
        
        // x and y need to be separated and treated differently (for movement and jump)
        float velocityX = rb.velocity.x;
        float velocityY = rb.velocity.y;

        // Clamp max speed
        velocityX = Mathf.Clamp(velocityX, -MaxMovementSpeed, MaxMovementSpeed);

        // If not pressing a button to move horizontally
        if (playerMovement.x == 0)
        {
            // Slow the player from current movement speed down to 0 using movementDamping
            velocityX = Mathf.Lerp(velocityX, 0, Time.fixedUnscaledDeltaTime * MovementDamping);
        }
        
        Vector3 combinedVelocity = new Vector3(velocityX, velocityY, 0);
        rb.velocity = combinedVelocity;
    }

    private void TryJumpOrGroundSlam()
    {
        // If player is on the ground, jump
        if (groundedChecker.IsGrounded)
        {
            remainingJumpForce = JumpStrength;
            
        }
        // If player is not on the ground and is holding down, ground slam
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (!canSlam)
            {
                return;
            }
            
            remainingJumpForce = -SlamStrength;
            canSlam = false;
        }
    }
}