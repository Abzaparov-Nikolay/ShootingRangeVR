using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Tester : MonoBehaviour
{
    public TeleportationProvider provider;
    public XRVariablesSO variables;
    // Start is called before the first frame update
    void Start()
    {
        if(provider != null)
        {
            Debug.Log("Teleport Provider found");
        }
        if(variables.continuousTurnProvider!= null)
        {
            Debug.Log("NICE");
            variables.continuousTurnProvider.enabled = false;
        }
    }

    
}
