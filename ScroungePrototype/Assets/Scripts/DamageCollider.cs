using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour, IClearable
{
    public void Clear()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponentInChildren<IDamageable>();
        if(damageable != null)
        {
            damageable.Damage();
            Destroy(gameObject);
        }
        else
        {
            print(collision.gameObject.name + ": IDamagable is null");
        }
    }

}
