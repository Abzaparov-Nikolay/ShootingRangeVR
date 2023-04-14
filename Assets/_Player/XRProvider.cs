using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRProvider : MonoBehaviour
{
    public XRVariablesSO xrVariablesSO;

    //public GameObject Origin;
    public XROrigin xrOrigin;
    public XRInteractionManager interactionManager;
    public TeleportationProvider teleportationProvider;
    public DeviceBasedSnapTurnProvider snapTurnProvider;
    public DeviceBasedContinuousTurnProvider continuousTurnProvider;
    public DeviceBasedContinuousMoveProvider continuousMoveProvider;
    public FeedbackManager feedbackManager;

    private void Awake()
    {
        //xrVariablesSO.Origin = Origin;
        xrVariablesSO.xrOrigin = xrOrigin;
        xrVariablesSO.teleportationProvider = teleportationProvider;
        xrVariablesSO.snapTurnProvider = snapTurnProvider;
        xrVariablesSO.continuousTurnProvider = continuousTurnProvider;
        xrVariablesSO.continuousMoveProvider = continuousMoveProvider;
        xrVariablesSO.feedbackManager = feedbackManager;
    }
}
