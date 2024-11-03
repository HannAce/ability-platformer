using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameplayConfig gameplayConfig;

    private float movementSpeed;
    private float jump;

    // Start is called before the first frame update
    void Start()
    {
        if (gameplayConfig != null)
        {
            InitialiseGameplayConfig();
        }
        else
        {
            Debug.LogError("Error: GameplayConfig is missing a reference for the Player script!");
        }
    }

    private void InitialiseGameplayConfig()
    {
        movementSpeed = gameplayConfig.PlayerMovementSpeed;
        jump = gameplayConfig.PlayerJumpHeight;
    }

        // Update is called once per frame
        void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * jump);
        }
    }
}
