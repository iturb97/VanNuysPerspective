using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 2.5f;
    public float rotationSpeed = 100f;
    public float gravity = -9.81f;
    public float groundStickForce = -5f;
    
    private Vector3 velocity;

    private CharacterController characterController;
    
    public PlayerState playerState;
    
    public PlayerStaminaManager staminaManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerState = GetComponent<PlayerState>();
        staminaManager = GetComponent<PlayerStaminaManager>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = groundStickForce;
        }
        
        float moveInput = 0f;
        float turnInput = 0f;

        if (Keyboard.current.wKey.isPressed) moveInput = 1f;
        if (Keyboard.current.sKey.isPressed) moveInput = -1f;
        
        if (Keyboard.current.dKey.isPressed) turnInput = 1f;
        if (Keyboard.current.aKey.isPressed) turnInput = -1f;
        
        if (moveInput != 0f)
        {
            playerState.isMoving = true;
            staminaManager.StaminaDrain();
            
        }
        else
        {
            playerState.isMoving = false;
            staminaManager.StaminaRegen();
        }
        
        
        transform.Rotate(0f, turnInput * rotationSpeed * Time.deltaTime, 0f);
        
        Vector3 movement = transform.forward * moveInput * movementSpeed;
        velocity.y += gravity * Time.deltaTime;
        movement.y = velocity.y;
        characterController.Move(movement * Time.deltaTime);
    }

    
}
