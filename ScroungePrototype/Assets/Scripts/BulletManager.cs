using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour, IClearable, IEdible, IAttractable
{
    private PlayerEat playerEat;
    private PlayerShoot playerShoot;
    private PlayerSize playerSize;
    private int bulletsEaten;

    private void Awake()
    {
        GameObject player = GameObject.Find("Player");
        playerShoot = player.GetComponent<PlayerShoot>();
        playerSize = player.GetComponent<PlayerSize>();
        playerEat = player.GetComponent<PlayerEat>();
    }

    public void Clear()
    {
        Destroy(gameObject);
    }

    public void Attract()
    {

    }

    public void Eat()
    {
        Destroy(gameObject);
        bulletsEaten++;
        playerShoot.AmmunitionCount++;
        print(playerShoot.AmmunitionCount);
        if (bulletsEaten % 20 == 0)
        {
            playerSize.IncreasePlayerScale(0.01f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponentInChildren<IDamageable>();
        if(damageable != null)
        {
            if (collision.gameObject.CompareTag("Player") && playerEat.IsEating) return;
            damageable.Damage();
            Destroy(gameObject);
        }
        
    }

}
