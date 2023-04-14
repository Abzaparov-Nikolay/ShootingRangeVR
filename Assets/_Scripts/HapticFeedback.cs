using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class HapticFeedback : MonoBehaviour
{
    public float duration;
    [Range(0f, 1f)]
    public float impulse;
    public XRVariablesSO xrVariables;
    public XRGrabInteractable grab;
    public GrabInspector grabInspector;

    [ContextMenu("Test feedback")]
    public void GiveFeedback()
    {
        if(grabInspector!=null)
        {
            foreach(var controller in grabInspector.GetInteractingControllers())
            {
                xrVariables.feedbackManager.ReceiveFeedback(duration, impulse, controller);
            }
        }

        var kek = grab.interactorsSelecting;
        foreach(var controller in kek)
        {
            xrVariables.feedbackManager.ReceiveFeedback(duration, impulse, controller);
        }

        
    }
}
