using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[CreateAssetMenu(menuName ="XRVariables")]
public class XRVariablesSO : ScriptableObject
{
    //public GameObject Origin;
    public XROrigin xrOrigin;
    public TeleportationProvider teleportationProvider;
    public DeviceBasedSnapTurnProvider snapTurnProvider;
    public DeviceBasedContinuousTurnProvider continuousTurnProvider;
    public DeviceBasedContinuousMoveProvider continuousMoveProvider;
}
