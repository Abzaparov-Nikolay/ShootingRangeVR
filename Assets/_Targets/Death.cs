using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    public UnityEvent OnDeath;
    public bool DestroyOnDeath = true;
    public UnityEvent<object> onDestroy;
    
    private void OnDestroy()
    {
        onDestroy?.Invoke(gameObject);
    }

    [ContextMenu("Die")]
    public void Die()
    {
        OnDeath?.Invoke();
        if (DestroyOnDeath)
        {
            Destroy(gameObject);
        }
    }
}
