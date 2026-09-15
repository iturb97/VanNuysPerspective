using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    public float sprintSpeedMultiplier = 1.5f;

    public PlayerState playerState;

    public PlayerController playerController;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState.isSprinting)
        {
            playerController.movementSpeed *= sprintSpeedMultiplier;
        }
    }

    public void PlayerSprint()
    {
        
    }
}
