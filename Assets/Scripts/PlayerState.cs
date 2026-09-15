using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Debug;


public class PlayerState : MonoBehaviour
{
    public bool isMoving = false;
    public bool isWalking = false;
    public bool isAlive = true;
    
    public Transform respawnPoint;
    
    private CharacterController characterController;
    
    private PlayerStaminaManager staminaManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        staminaManager = GetComponent<PlayerStaminaManager>();
        staminaManager.currentStamina = staminaManager.maxStamina;
    }

    // Update is called once per frame
    void Update()
    {

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
