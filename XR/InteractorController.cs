using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractorController : MonoBehaviour
{
    [Header("Interactor")]
    [SerializeField] XRRayInteractor rayInteractor;
    [SerializeField] XRRayInteractor teleportInteractor;

    [Header("Action")]
    [SerializeField] InputActionProperty teleportModeActivate;

    private void OnEnable()
    {
        teleportModeActivate.action.performed += OnStartTeleport;
        teleportModeActivate.action.canceled += OnCancelTeleport;
    }

    private void OnDisable()
    {
        teleportModeActivate.action.performed -= OnStartTeleport;
        teleportModeActivate.action.canceled -= OnCancelTeleport;
    }

    private void Start()
    {
        rayInteractor.gameObject.SetActive(true);
        teleportInteractor.gameObject.SetActive(false);
    }

    private void OnStartTeleport(InputAction.CallbackContext context)
    {
        rayInteractor.gameObject.SetActive(false);
        teleportInteractor.gameObject.SetActive(true);
    }

    private void OnCancelTeleport(InputAction.CallbackContext context)
    {
        rayInteractor.gameObject.SetActive(true);

        // Do not deactivate the teleport interactor in this callback.
        // We delay turning off the teleport interactor in this callback so that
        // the teleport interactor has a chance to complete the teleport if needed.
        // OnAfterInteractionEvents will handle deactivating its GameObject.
        StartCoroutine(TeleportConfirmDelay());
    }

    IEnumerator TeleportConfirmDelay()
    {
        yield return new WaitForEndOfFrame();
        teleportInteractor.gameObject.SetActive(false);
    }
}
