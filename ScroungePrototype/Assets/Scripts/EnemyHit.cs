using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private EnemySize enemySize;
    private PlayerShoot playerShoot;
    private int enemyHealth = 10;
    private int bulletsStored;

    private void Awake()
    {
        enemySize = GetComponent<EnemySize>();
        playerShoot = GameObject.Find("Player").GetComponent<PlayerShoot>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            enemySize.ScaleUpEnemy();
            bulletsStored++;
        }

        if(transform.localScale.x >= enemySize.MaxScale)
        {
            enemyHealth--;
        }

        if(enemyHealth <= 0)
        {
            playerShoot.AmmunitionCount += bulletsStored + (int)Mathf.Round(bulletsStored * .5f);
            Destroy(gameObject);
        }
    }
}
