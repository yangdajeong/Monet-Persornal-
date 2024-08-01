using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionManager : MonoBehaviour
{
    public enum MoveStyleType { HeadRelative, HandRelative }
    public enum TurnStyleType { Snap, Continuous }

    [Header("XR")]
    [SerializeField] XROrigin xrOrigin;
    [SerializeField] XRBaseController leftController;
    [SerializeField] XRBaseController rightController;

    [Header("Locomotion")]
    [SerializeField] ContinuousMoveProviderBase continuousMoveProvider;
    [SerializeField] ContinuousTurnProviderBase continuousTurnProvider;
    [SerializeField] SnapTurnProviderBase snapTurnProvider;
    [SerializeField] TeleportationProvider teleportationProvider;

    [Header("Property")]
    [SerializeField] MoveStyleType leftHandMoveStyle;
    public MoveStyleType MoveStyle
    {
        get { return leftHandMoveStyle; }
        set
        {
            leftHandMoveStyle = value;
            switch (leftHandMoveStyle)
            {
                case MoveStyleType.HeadRelative:
                    continuousMoveProvider.forwardSource = xrOrigin.Camera.transform;
                    break;
                case MoveStyleType.HandRelative:
                    continuousMoveProvider.forwardSource = leftController.transform;
                    break;
            }
        }
    }

    [SerializeField] TurnStyleType rightHandTurnStyle;
    public TurnStyleType TurnStyle
    {
        get { return rightHandTurnStyle; }
        set
        {
            rightHandTurnStyle = value;
            switch (rightHandTurnStyle)
            {
                case TurnStyleType.Snap:
                    continuousTurnProvider.enabled = false;
                    snapTurnProvider.enabled = true;
                    break;
                case TurnStyleType.Continuous:
                    continuousTurnProvider.enabled = true;
                    snapTurnProvider.enabled = false;
                    break;
            }
        }
    }

    [SerializeField, Range(0f, 5f)] float moveSpeed;
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set
        {
            moveSpeed = value;
            continuousMoveProvider.moveSpeed = moveSpeed;
        }
    }

    [SerializeField] bool enableStrafe;
    public bool EnableStrafe
    {
        get { return enableStrafe; }
        set
        {
            enableStrafe = value;
            continuousMoveProvider.enableStrafe = enableStrafe;
        }
    }

    [SerializeField] bool useGravity;
    public bool UseGravity
    {
        get { return useGravity; }
        set
        {
            useGravity = value;
            continuousMoveProvider.useGravity = useGravity;
        }
    }

    [SerializeField] bool enableFly;
    public bool EnableFly
    {
        get { return enableFly; }
        set
        {
            enableFly = value;
            continuousMoveProvider.enableFly = enableFly;
        }
    }

    [SerializeField, Range(0f, 180f)] float turnSpeed;
    public float TurnSpeed
    {
        get { return turnSpeed; }
        set
        {
            turnSpeed = value;
            continuousTurnProvider.turnSpeed = turnSpeed;
        }
    }

    [SerializeField] bool enableTurnAround;
    public bool EnableTurnAround
    {
        get { return enableTurnAround; }
        set
        {
            enableTurnAround = value;
            snapTurnProvider.enableTurnAround = enableTurnAround;
        }
    }

    [SerializeField, Range(0f, 90f)] float snapTurnAmount;
    public float SnapTurnAmount
    {
        get { return snapTurnAmount; }
        set
        {
            snapTurnAmount = value;
            snapTurnProvider.turnAmount = snapTurnAmount;
        }
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        MoveStyle = leftHandMoveStyle;
        TurnStyle = rightHandTurnStyle;
        MoveSpeed = moveSpeed;
        EnableStrafe = enableStrafe;
        UseGravity = useGravity;
        EnableFly = enableFly;
        TurnSpeed = turnSpeed;
        EnableTurnAround = enableTurnAround;
        SnapTurnAmount = snapTurnAmount;
    }
}
