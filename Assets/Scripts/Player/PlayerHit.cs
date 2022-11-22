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
    private RestartManager restartManager;
    private SpriteRenderer spriteRenderer;
    private Dash dash;

    private void Awake()
    {
        spriteRenderer = GameObject.Find("PlayerAnimation").GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        restartManager = GameObject.Find("RestartManager").GetComponent<RestartManager>();
        dash = player.GetComponent<Dash>();
    }

    private void Update()
    {
        DestroyPlayer();    
    }

    public void Damage()
    {
        if (canBeDamaged == false) return;
        if (dash.IsDashing) return;
        playerHealth--;
        DecrementHealthUI();
        StartCoroutine(ImmunityCooldownCoroutine(immunityTime));
        StartCoroutine(SpriteFlashCoroutine(spriteRenderer, 5, .1f));
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

    private IEnumerator SpriteFlashCoroutine(SpriteRenderer sprite, int maxIterations, float pauseDuration)
    {
        for(int i = 0; i < maxIterations; i++)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(pauseDuration);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(pauseDuration);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(dash.IsDashing)
        {
            var enemyVelocity = collision.gameObject.GetComponent<Rigidbody2D>();
            if(enemyVelocity != null)
            {
                //enemyVelocity.AddForce(collision.transform.position * 3000 * Time.deltaTime)
                enemyVelocity.velocity *= 2;
            }
        }
    }

}
