using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameplayConfig gameplayConfig;

    [SerializeField] private Rigidbody rb;

    private float movementSpeed;
    private float jump;

    // Start is called before the first frame update
    private void Start()
    {
        if (gameplayConfig == null)
        {
            Debug.LogError("Error: GameplayConfig is missing a reference for the Player script!");
            return;
        }

        InitialiseGameplayConfig();
    }

    private void InitialiseGameplayConfig()
    {
        movementSpeed = gameplayConfig.PlayerMovementSpeed;
        jump = gameplayConfig.PlayerJumpHeight;
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector3 playerMovement = default; // start at default 0 value

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerMovement += Vector3.left * movementSpeed;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playerMovement += Vector3.right * movementSpeed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            playerMovement += Vector3.up * jump;
        }

        rb.MovePosition(rb.position + playerMovement * Time.deltaTime);
    }
}