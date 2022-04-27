using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHit : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject[] healthUIs;
    private int playerHealth = 3;
    private GameObject player;
    private PlayerEat playerEat;
    private RestartManager restartManager;


    private void Awake()
    {
        player = GameObject.Find("Player");
        playerEat = player.GetComponent<PlayerEat>();
        restartManager = GameObject.Find("RestartManager").GetComponent<RestartManager>();
    }

    private void Update()
    {
        DestroyPlayer();
    }

    public void Damage()
    {
        if (playerEat.IsEating) return;
        playerHealth--;
        DecrementHealthUI();
    }

    private void DecrementHealthUI()
    {
        healthUIs[playerHealth].SetActive(false);    
    }

    private void DestroyPlayer()
    {
        if(player == null) return;
        if(playerHealth <= 0)
        {
            Destroy(player);
            restartManager.StopTime();
            restartManager.EnableGameOverScreen();
        }
    }

    

}
