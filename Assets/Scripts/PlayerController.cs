using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private float movementSpeed = 2.5f;
    public float baseMovementSpeed = 2.5f;
    private float rotationSpeed = 100f;

    public float baseRotationSpeed = 100f;
    public float gravity = -9.81f;
    public float groundStickForce = -5f;

    public float sprintSpeedMultiplier = 3.0f;
    
    private Vector3 velocity;

    private CharacterController characterController;
    
    public PlayerState playerState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerState = GetComponent<PlayerState>();
        
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
        
        playerState.isMoving = moveInput != 0f;

        transform.Rotate(0f, turnInput * rotationSpeed * Time.deltaTime, 0f);
        
        CheckSprintSpeed();
        
        Vector3 movement = transform.forward * moveInput * movementSpeed;
        velocity.y += gravity * Time.deltaTime;
        movement.y = velocity.y;
        characterController.Move(movement * Time.deltaTime);
    }

    public void ResetVelocity()
    {
        velocity = Vector3.zero;
    }

    public void CheckSprintSpeed()
    {
        if (playerState.isSprinting)
        {
            movementSpeed = baseMovementSpeed * sprintSpeedMultiplier;
        }
        else
        {
            movementSpeed = baseMovementSpeed;
        }
    }

    
}
