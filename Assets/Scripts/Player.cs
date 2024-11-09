using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameplayConfig gameplayConfig;
    
    [SerializeField] private Rigidbody rb;
    
    private Vector3 playerMovement;
    private float remainingJumpForce;
    
    private float MovementAcceleration => gameplayConfig.MovementAcceleration;
    private float MaxMovementSpeed => gameplayConfig.MaxMovementSpeed;
    private float JumpHeight => gameplayConfig.JumpHeight;
    private float MovementDamping => gameplayConfig.MovementDamping;

    // Start is called before the first frame update
    private void Start()
    {
        if (gameplayConfig == null)
        {
            Debug.LogError("Error: GameplayConfig is missing a reference for the Player script!");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();
    }

    private void FixedUpdate()
    {
        rb.AddForce(playerMovement, ForceMode.Impulse);

        if (remainingJumpForce > 0)
        {
            rb.AddForce(Vector3.up * remainingJumpForce, ForceMode.Impulse);
            remainingJumpForce = 0;
        }
        
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
        
        // if (rb.velocity.magnitude > MaxMovementSpeed)
        // {
        //     rb.velocity = rb.velocity.normalized * MaxMovementSpeed;
        //     Debug.Log("Clamping to max speed");
        // }
    }

    private void PlayerMovement()
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
            //playerMovement += Vector3.up * jump;
            remainingJumpForce = JumpHeight;
        }
    }
}