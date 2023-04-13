using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FloatVariableSO : ScriptableObject
{
    public event Action onChanged;
    [SerializeField] private float value;
    [SerializeField] protected float initialValue;

    public float Get() => value;

    public void Set(float newValue)
    {
        value = newValue;
        onChanged?.Invoke();
    }

    public void Add(float delta)
    {
        Set(delta + value);
    }

    private void OnEnable()
    {
        this.Set(initialValue);
    }
}
