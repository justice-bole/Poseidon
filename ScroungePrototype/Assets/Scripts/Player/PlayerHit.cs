using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHit : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject[] healthUIs;
    [SerializeField] private float immunityTime = 1;
    private bool canBeDamaged = true;
    private int playerHealth = 3;
    private GameObject player;
    private PlayerEat playerEat;
    private RestartManager restartManager;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GameObject.Find("PlayerAnimation").GetComponent<SpriteRenderer>();
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
        if (canBeDamaged == false) return;
        playerHealth--;
        DecrementHealthUI();
        StartCoroutine(ImmunityCooldownCoroutine(immunityTime));
        StartCoroutine(SpriteFlashCoroutine());
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

    private IEnumerator ImmunityCooldownCoroutine(float immunityTime)
    {
        canBeDamaged = false;
        yield return new WaitForSeconds(immunityTime);
        canBeDamaged = true;
    }   

    private IEnumerator SpriteFlashCoroutine()
    {
        for(int i = 0; i < 5; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(.1f);
        }
    }

}
