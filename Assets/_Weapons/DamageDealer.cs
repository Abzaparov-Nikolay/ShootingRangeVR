using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float Damage;

    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        if(health != null)
        {
            health.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
