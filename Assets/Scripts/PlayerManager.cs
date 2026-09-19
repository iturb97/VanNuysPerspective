using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public float sprintDrainRate = 35f;
    public float sprintRecoveryThreshold = 20f;

    public Transform respawnPoint;
    public float respawnDelay = 1f;

    private PlayerState playerState;
    private PlayerStaminaManager staminaManager;
    private PlayerController playerController;
    private CharacterController characterController;

    private bool sprintLocked;

    void Start()
    {
        playerState = GetComponent<PlayerState>();
        staminaManager = GetComponent<PlayerStaminaManager>();
        playerController = GetComponent<PlayerController>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!playerState.isAlive) return;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillPlane") && playerState.isAlive)
        {
            StartCoroutine(DieAndRespawn());
        }
    }

    private IEnumerator DieAndRespawn()
    {
        playerState.isAlive = false;
        playerState.isMoving = false;
        playerState.isSprinting = false;
        playerController.enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        // CharacterController overrides transform.position while enabled.
        characterController.enabled = false;
        transform.position = respawnPoint != null ? respawnPoint.position : Vector3.zero;
        characterController.enabled = true;

        playerController.ResetVelocity();
        staminaManager.currentStamina = staminaManager.maxStamina;
        sprintLocked = false;

        playerController.enabled = true;
        playerState.isAlive = true;
    }
}
