using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour, IDamageable
{
    private EnemySize enemySize;
    private int enemyHealth = 10;
    private int bulletsStored;
    private PlayerShoot playerShoot;
    private PlayerSize playerSize;

    private void Awake()
    {
        enemySize = GetComponent<EnemySize>();
        playerSize = GameObject.Find("Player").GetComponent<PlayerSize>();
        playerShoot = GameObject.Find("Player").GetComponent<PlayerShoot>();
    }

    public void Damage()
    {
        enemySize.ScaleUpEnemy();
        bulletsStored++;

        if (transform.localScale.x >= enemySize.MaxScale)
        {
            enemyHealth--;
        }

        if (enemyHealth <= 0)
        {
            playerShoot.AmmunitionCount += bulletsStored + (int)Mathf.Round(bulletsStored * .25f);
            playerSize.IncreasePlayerScale(.1f);
            Destroy(gameObject);
        }
    }
}
