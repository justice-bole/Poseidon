using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    private int playerHealth = 3;
    private GameObject player;
    private PlayerEat playerEat;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerEat = player.GetComponent<PlayerEat>();
    }

    private void Update()
    {
        DestroyPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        if (collision.CompareTag("Bullet") && !playerEat.IsEating)
        {
            Destroy(collision.gameObject);
            playerHealth--;
        }
        if(collision.CompareTag("Enemy"))
        {
            playerHealth--;
        }
    }

    private void DestroyPlayer()
    {
        if(player == null) return;
        if(playerHealth <= 0)
        {
            Destroy(player);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
