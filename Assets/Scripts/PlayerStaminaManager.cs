using UnityEngine;

public class PlayerStaminaManager : MonoBehaviour
{
    public float currentStamina = 100f;
    public float maxStamina = 100f;
    public float staminaRegenRate = 10f;
    public float staminaDrainRate = 20f;
    public float minStamina = 0f;

    void Start()
    {
        currentStamina = maxStamina;
    }

    public void Drain(float rate)
    {
        currentStamina = Mathf.Max(currentStamina - rate * Time.deltaTime, minStamina);
    }

    public void Regen(float rate)
    {
        currentStamina = Mathf.Min(currentStamina + rate * Time.deltaTime, maxStamina);
    }
}
