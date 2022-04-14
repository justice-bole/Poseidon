using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private PlayerShoot playerShoot;
    private PlayerSize playerSize;
    private int bulletsEaten;


    private void Awake()
    {
        playerShoot = GameObject.Find("Player").GetComponent<PlayerShoot>();
        playerSize = GameObject.Find("PlayerSprite").GetComponent<PlayerSize>();
    }

    private void Update()
    {
        if(bulletsEaten >= 100)
            bulletsEaten = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            bulletsEaten++;
            playerShoot.AmmunitionCount++;
            print(playerShoot.AmmunitionCount);

            if (bulletsEaten % 20 == 0)
            {
                playerSize.IncreasePlayerScale();
            }
        }
    }
}
