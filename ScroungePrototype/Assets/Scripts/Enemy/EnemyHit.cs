using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour, IDamageable, IClearable
{
    [SerializeField] private GameObject deathActor;
 
    private GameObject player;
    private Animator animator;
    private bool mustClear = false;
    private int enemyHealth = 10;
    private int bulletsStored;
    private float justHitCD = 0.1f;
    private PlayerShoot playerShoot;
    private ScaleManager scaleManager;
    private GemSpawner gemSpawner;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        gemSpawner = GameObject.Find("GemSpawner").GetComponent<GemSpawner>();
        scaleManager = GameObject.Find("ScaleManager").GetComponent<ScaleManager>();
        player = GameObject.Find("Player");
        playerShoot = GameObject.Find("Player").GetComponent<PlayerShoot>();   
    }

    public void Clear()
    {
        PlayDeathAnimation();
        Destroy(gameObject);
    }

    public void Damage()
    {
        StopCoroutine(JustHitCDCoroutine());
        StartCoroutine(JustHitCDCoroutine());
        scaleManager.ChangeObjectScale(gameObject, .04f);
        bulletsStored++;
        CheckVulnerability();
        CheckIfDead();
    }

    private void CheckVulnerability()
    {
        if (transform.localScale.x >= 1.5f)
        {
            animator.SetBool("isVulnerable", true);
            enemyHealth--;
        }
    }

    private void CheckIfDead()
    {
        if (enemyHealth <= 0 || mustClear)
        {
            PlayDeathAnimation();
            gemSpawner.SpawnGems(this.gameObject);
            playerShoot.AmmunitionCount += bulletsStored + (int)Mathf.Round(bulletsStored * .25f);
            if(player.transform.localScale.x <= 1.25f)
            {
                scaleManager.ChangeObjectScale(player, .1f);
            }
            Destroy(gameObject);
        }
    }

    private void PlayDeathAnimation()
    {
        var deathAnimation = Instantiate(deathActor, transform.position, Quaternion.identity);
        Destroy(deathAnimation, .7f);
    }

    private IEnumerator JustHitCDCoroutine()
    {
        animator.SetBool("justHit", true);
        yield return new WaitForSeconds(justHitCD);
        animator.SetBool("justHit", false);
    }

}
