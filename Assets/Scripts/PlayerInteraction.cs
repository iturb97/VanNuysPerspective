using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform cameraTransform;
    public float interactionDistance = 3f;

    public Image crosshairImage;
    public Color defaultCrosshairColor = Color.white;
    public Color interactableCrosshairColor = Color.green;
    
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
        RaycastHit hit;
        bool didHit = Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactionDistance);
        
        if (didHit)
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            
            if (interactable != null)
            {
                crosshairImage.color = interactableCrosshairColor;
            }
            else
            {
                crosshairImage.color = defaultCrosshairColor;
            }
            
        }
        else
        {
            crosshairImage.color = defaultCrosshairColor;
        }
    }

    void TryInteract()
    {
        RaycastHit hit;
        bool didHit = Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactionDistance);

        if (didHit)
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
