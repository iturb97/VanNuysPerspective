using UnityEngine;
using System;

public class CameraBobbing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    public PlayerState playerState;
    public Camera camera;

    public float walkFrequency = 12f;
    public float sprintFrequency = 18f;
    public float walkAmplitude = 0.04f;
    public float sprintAmplitude = 0.07f;
    public float cameraReturnSpeed = 2.0f;
    public float bobTimer = 0f;

    private Vector3 resetPosition = Vector3.zero;
    
    
    
    
    void Start()
    {
        camera = GetComponent<Camera>();
        
        if (playerState == null)
        {
            playerState = GetComponentInParent<PlayerState>();
            resetPosition = camera.transform.localPosition;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        CameraBob();
    }
    
    public void CameraBob()
    {
        if (playerState == null || camera == null) return;
        if (playerState.isMoving && playerState.isAlive)
        {
            float frequency;
            if (playerState.isSprinting)
            {
                frequency = sprintFrequency;
            }
            else
            {
                frequency = walkFrequency;
            }
            
            float amplitude;
            if (playerState.isSprinting)
            {
                amplitude = sprintAmplitude;
            }
            else
            {
                amplitude = walkAmplitude;
            }
            
            bobTimer += Time.deltaTime * frequency;
            float offsetY = Mathf.Sin(bobTimer) * amplitude;
            camera.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y + offsetY, resetPosition.z);
        }
        else
        {
            bobTimer = 0f;
            camera.transform.localPosition =
                Vector3.Lerp(camera.transform.localPosition, resetPosition, Time.deltaTime * cameraReturnSpeed);

        }
    }
}
