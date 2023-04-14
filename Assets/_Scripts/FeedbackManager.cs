using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class FeedbackManager : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.XRController right;
    public UnityEngine.XR.Interaction.Toolkit.XRController left;

    public void ReceiveFeedback(float duration, float impulse, Controller controller)
    {
        if (controller == Controller.Right)
            right.SendHapticImpulse(impulse, duration);
        else if (controller == Controller.Left)
            left.SendHapticImpulse(impulse, duration);
        else
        {
            right.SendHapticImpulse(impulse, duration);
            left.SendHapticImpulse(impulse, duration);
        }
    }

    public void ReceiveFeedback(float duration, float impulse, XRBaseController controller)
    {
        controller.SendHapticImpulse(impulse, duration);
    }

    public void ReceiveFeedback(float duration, float impulse, IXRSelectInteractor controller)
    {
        controller.transform.gameObject.GetComponent<XRBaseController>().SendHapticImpulse(impulse, duration);
    }
}

public enum Controller
{
    Left,
    Right,
    Both
}
