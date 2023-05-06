using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private Collider _pressTrigger;

    private bool _isPressed;
    private ConfigurableJoint _joint;
    
    public UnityEvent Pressed, Released;

    private void OnEnable()
    {
        Pressed.AddListener(OnPressed);
        Released.AddListener(OnReleased);
    }
    
    private void OnDisable()
    {
        Pressed.RemoveListener(OnPressed);
        Released.RemoveListener(OnReleased);
    }

    private void Start()
    {
        _joint = GetComponent<ConfigurableJoint>();
    }
    
    private void OnPressed()
    {
        Debug.Log("Pressed");
    }
    
    private void OnReleased()
    {
        Debug.Log("Released");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == _pressTrigger)
        {
            Pressed.Invoke();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other == _pressTrigger)
        {
            Released.Invoke();
        }
    }
}
