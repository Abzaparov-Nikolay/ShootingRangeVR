using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class GrabInspector : MonoBehaviour
{
    public List<XRBaseController> interactors;
    private XRGrabInteractable grab;

    private void Start()
    {
        interactors = new();
        grab = GetComponent<XRGrabInteractable>();
        grab.selectEntered.AddListener(AddInteractingController);
        grab.selectExited.AddListener(RemoveInteractingController);
    }

    private void AddInteractingController(SelectEnterEventArgs args)
    {
        interactors.Add(args.interactorObject.transform.gameObject.GetComponent<XRBaseController>());
    }

    private void RemoveInteractingController(SelectExitEventArgs args)
    {
        interactors.Remove(args.interactorObject.transform.gameObject.GetComponent<XRBaseController>());
    }

    public List<XRBaseController> GetInteractingControllers()
    {
        return interactors.ToList();
    }
}
