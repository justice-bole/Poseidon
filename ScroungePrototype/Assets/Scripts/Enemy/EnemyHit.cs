using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour, IDamageable, IClearable
{
    [SerializeField] private GameObject deathActor;
    [SerializeField] private GameObject gemPrefab;
    private Animator animator;
    private bool mustClear = false;
    private int enemyHealth = 10;
    private int bulletsStored;
    private float justHitCD = 0.1f;
    private PlayerShoot playerShoot;
    private ScaleManager scaleManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        scaleManager = GameObject.Find("ScaleManager").GetComponent<ScaleManager>();
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
        scaleManager.ChangeObjectScale(this.gameObject, .04f);
        bulletsStored++;

        if (transform.localScale.x >= 1.5f)
        {
            animator.SetBool("isVulnerable", true);
            enemyHealth--;
        }

        if (enemyHealth <= 0 || mustClear)
        {
            PlayDeathAnimation();
            SpawnGems();
            playerShoot.AmmunitionCount += bulletsStored + (int)Mathf.Round(bulletsStored * .25f);
            scaleManager.ChangeObjectScale(this.gameObject, .1f);
            Destroy(gameObject);
        }
    }

    private void SpawnGems()
    {
        int random = Random.Range(0, 3);
        for (int i = 0; i < random; i++)
        {
            Instantiate(gemPrefab, transform.position, Quaternion.identity);
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
