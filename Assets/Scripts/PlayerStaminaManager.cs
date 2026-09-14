using UnityEngine;

public class PlayerStaminaManager : MonoBehaviour
{
    
    public PlayerState playerState;

    public float currentStamina = 100f;
    public float maxStamina = 100f;
    public float staminaRegenRate = 10f;
    public float staminaDrainRate = 20f;
    public float minStamina = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StaminaDrain()
    {
        currentStamina -= staminaDrainRate * Time.deltaTime;
        if (currentStamina < minStamina) currentStamina = minStamina;
    }

    public void StaminaRegen()
    {
        currentStamina += staminaRegenRate * Time.deltaTime;
        if (currentStamina > maxStamina) currentStamina = maxStamina;
    }
    
    public void UpdateStamina()
    {
        
    }
}
