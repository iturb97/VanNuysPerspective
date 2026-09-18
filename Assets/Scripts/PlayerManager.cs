using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public float sprintDrainRate = 35f;
    public float sprintRecoveryThreshold = 20f;

    private PlayerState playerState;
    private PlayerStaminaManager staminaManager;

    private bool sprintLocked;

    void Start()
    {
        playerState = GetComponent<PlayerState>();
        staminaManager = GetComponent<PlayerStaminaManager>();
    }

    void Update()
    {
        // Locking until stamina climbs back to the threshold stops sprint from
        // re-engaging for a frame at a time once the bar bottoms out.
        if (staminaManager.currentStamina <= staminaManager.minStamina) sprintLocked = true;
        else if (staminaManager.currentStamina >= sprintRecoveryThreshold) sprintLocked = false;

        bool wantsToSprint = Keyboard.current.leftShiftKey.isPressed;
        playerState.isSprinting = wantsToSprint && playerState.isMoving && !sprintLocked;

        if (playerState.isSprinting) staminaManager.Drain(sprintDrainRate);
        else if (playerState.isMoving) staminaManager.Drain(staminaManager.staminaDrainRate);
        else staminaManager.Regen(staminaManager.staminaRegenRate);
    }
}
