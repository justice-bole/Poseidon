using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionCallDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponentInChildren<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage();
        }
    }
}
