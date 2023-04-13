using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float MaxHealth =10;
    public float CurrentHealth;
    public UnityEvent OnDamaged;
    public UnityEvent OnCurrentZero;

    private void OnEnable()
    {
        CurrentHealth = MaxHealth;
    }

    
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if(damage > 0)
        {
            OnDamaged?.Invoke();
        }
        if(CurrentHealth <= 0 )
        {
            OnCurrentZero?.Invoke();
        }
    }

    [ContextMenu("TakeDamage")]
    public void TestSound()
    {
        TakeDamage(1);
        
    }
}
