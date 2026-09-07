using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 200f;

    public float minimumYLookAngle = -60f;
    public float maximumYLookAngle = 60f;
    public float minimumXLookAngle = -90f;
    public float maximumXLookAngle = 90f;
    
    private float xRotation = 0f;
    private float yRotation = 0f;
    
    private bool isReturning = false;
    
    private float returnSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Mouse.current.leftButton.isPressed)
        {
            isReturning = false;
            
            Vector2 mouseInput = Mouse.current.delta.ReadValue();
        
            xRotation += mouseInput.x * mouseSensitivity * Time.deltaTime;
            yRotation -= mouseInput.y * mouseSensitivity * Time.deltaTime;
        
            xRotation = Mathf.Clamp(xRotation, minimumXLookAngle, maximumXLookAngle);
            yRotation = Mathf.Clamp(yRotation, minimumYLookAngle, maximumYLookAngle);
        
            transform.localRotation = Quaternion.Euler(yRotation, xRotation, 0f);
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            isReturning = true;
        }
        
        if (isReturning)
        {
            xRotation = Mathf.Lerp(xRotation, 0, Time.deltaTime * returnSpeed);
            yRotation = Mathf.Lerp(yRotation, 0, Time.deltaTime * returnSpeed);
            transform.localRotation = Quaternion.Euler(yRotation, xRotation, 0f);
        }
        
    }
}
