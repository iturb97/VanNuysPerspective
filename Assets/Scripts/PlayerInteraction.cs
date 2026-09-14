using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform cameraTransform;
    public float interactionDistance = 3f;

    public CrosshairController crosshairController;
    
    
    private IInteractable currentInteractable;
    
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInteractable();
        
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryInteract();
        }
    }

    void CheckForInteractable()
    {
        currentInteractable = null;

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit,
                interactionDistance))
        {
            currentInteractable = hit.collider.GetComponent<IInteractable>();
        }

        if (currentInteractable != null)
        {
            crosshairController.SetColorInteractable();
        }
        else crosshairController.SetColorDefault();

    }

    void TryInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
        else crosshairController.SetColorDefault();
        
    }
}
