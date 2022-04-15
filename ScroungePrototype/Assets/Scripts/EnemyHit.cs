using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private EnemySize enemySize;
    private int enemyHealth = 25;

    private void Awake()
    {
        enemySize = GetComponent<EnemySize>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            enemySize.ScaleUpEnemy();
        }

        if(transform.localScale.x >= enemySize.MaxScale)
        {
            enemyHealth--;
        }

        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
