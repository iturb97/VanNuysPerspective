using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    public float sprintSpeedMultiplier = 3.0f;

    public PlayerState playerState;

    public PlayerController playerController;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerState = GetComponent<PlayerState>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState.isSprinting)
        {
            playerController.movementSpeed = playerController.maxMovementSpeed * sprintSpeedMultiplier;
            playerController.rotationSpeed = playerController.maxRotationSpeed * sprintSpeedMultiplier;
            //Debug.Log("Sprinting");
        }
        else
        {
            playerController.movementSpeed = playerController.maxMovementSpeed;
            playerController.rotationSpeed = playerController.maxRotationSpeed;
            //Debug.Log("Not sprinting");
        }
        
    }
    
}
