using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerState : MonoBehaviour
{
    public float playerHealth = 100f;
    
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDepletionRate = 20f;
    public float staminaRegenRate = 10f;

    public bool isSprinting;
    
    public bool isAlive = true;
    
    public Transform respawnPoint;
    
    private CharacterController characterController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isSprinting && currentStamina > 0f)
        {
            currentStamina -= staminaDepletionRate * Time.deltaTime;
            
        }
        else if (!isSprinting && currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            
        }
        
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillPlane"))
        {
            Respawn();
        }
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Die()
    {
        isAlive = false;
    }

    private void Respawn()
    {
        characterController.enabled = false;
        transform.position = respawnPoint.position;
        characterController.enabled = true;
    }
}
