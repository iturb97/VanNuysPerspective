using UnityEngine;

public class CameraBobbing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    public PlayerState playerState;
    public Camera camera;
    
    public float bobbingAmount = 0.1f;
    
    public float bobbingOffset = 0.0f;
    
    public float bobbingSpeed = 1.0f;
    
    public float bobbingSpeedSprint = 2.0f;
    
    
    
    void Start()
    {
        playerState = GetComponent<PlayerState>();
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        CameraBob();
    }
    
    public void CameraBob()
    {
        if (playerState.isMoving)
        {
            if (playerState.isSprinting)
            {
                
            }
            else
            {
                camera.transform.localPosition(new Vector3(0.0f, Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmount + bobbingOffset, 0.0f));
            }
        }
    }
}
