using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform cameraTransform;
    public float interactionDistance = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryInteract();
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
