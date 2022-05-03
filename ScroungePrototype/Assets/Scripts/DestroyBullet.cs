using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private PlayerShoot playerShoot;
    private PlayerSize playerSize;
    private PlayerEat playerEat;
    private int bulletsEaten;

    private void Awake()
    {
        GameObject player = GameObject.Find("Player");
        playerEat = player.GetComponent<PlayerEat>();
        playerShoot = player.GetComponent<PlayerShoot>();
        playerSize = player.GetComponent<PlayerSize>();
    }

   

    private void OnTriggerStay2D(Collider2D collision)
    {
        IEdible edible = collision.gameObject.GetComponentInChildren<IEdible>();
        if (edible != null && playerEat.IsEating)
        {
            edible.Eat();
        }
        if(collision.gameObject.CompareTag("Bullet") && playerEat.IsEating)
        {
            Destroy(collision.gameObject);
            bulletsEaten++;
            playerShoot.AmmunitionCount++;
            print(playerShoot.AmmunitionCount);

            if (bulletsEaten % 20 == 0)
            {
                playerSize.IncreasePlayerScale(0.01f);
            }
        }
    }
}
