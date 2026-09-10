using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Debug;


public class PlayerState : MonoBehaviour
{
    public float playerHealth = 100f;
    
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDepletionRate = 20f;
    public float staminaRegenRate = 10f;
    public float minStamina = 0f;
    public float sprintStaminaThreshold = 20f;
    
    public bool canSprint = false;

    public bool isMoving = false;
    
    public bool isSprinting;
    
    public bool isAlive = true;
    
    public Transform respawnPoint;
    
    private CharacterController characterController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentStamina = maxStamina;
        canSprint = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentStamina <= minStamina)
        {
            canSprint = false;
        }
        if (currentStamina > sprintStaminaThreshold)
        {
            canSprint = true;
        }
        
        if (isSprinting && currentStamina > minStamina)
        {
            currentStamina -= staminaDepletionRate * Time.deltaTime;
        }
        else if (!isSprinting && currentStamina < maxStamina && isMoving)
        {
            currentStamina += staminaRegenRate * Time.deltaTime * 0.25f;
        }
        else if (!isSprinting && currentStamina < maxStamina && !isMoving)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
        }
        
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

        int displayStamina = Mathf.RoundToInt(currentStamina);
        Log(displayStamina);
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
        if (respawnPoint == null)
        {
            respawnPoint = new GameObject().transform;
            respawnPoint.position = new Vector3(0, 0, 0);
        }
        characterController.enabled = false;
        transform.position = respawnPoint.position;
        characterController.enabled = true;
    }
}
