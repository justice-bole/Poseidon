using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour, IClearable, IEdible, IAttractable
{
    private GameObject player;
    private PlayerEat playerEat;
    private PlayerShoot playerShoot;
    private ScaleManager scaleManager;
    private int bulletsEaten;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerShoot = player.GetComponent<PlayerShoot>();
        scaleManager = GameObject.Find("ScaleManager").GetComponent<ScaleManager>();
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
        bulletsEaten++;
        playerShoot.AmmunitionCount++;
        print(playerShoot.AmmunitionCount);
        if (bulletsEaten % 20 == 0)
        {
            scaleManager.ChangeObjectScale(player, 0.01f);
        }
        Destroy(gameObject);
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
