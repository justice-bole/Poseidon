using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour, IDamageable, IClearable
{
    [SerializeField] private GameObject deathActor;
    private Animator animator;
    private EnemySize enemySize;
    private int enemyHealth = 10;
    private int bulletsStored;
    private float justHitCD = 0.1f;
    private PlayerShoot playerShoot;
    private PlayerSize playerSize;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemySize = GetComponent<EnemySize>();
        playerSize = GameObject.Find("Player").GetComponent<PlayerSize>();
        playerShoot = GameObject.Find("Player").GetComponent<PlayerShoot>();   
    }

    public void Clear()
    {
        Destroy(gameObject);
    }

    public void Damage()
    {
        StopCoroutine("JustHitCDCoroutine");
        StartCoroutine("JustHitCDCoroutine");
        enemySize.ScaleUpEnemy(.02f);
        bulletsStored++;

        if (transform.localScale.x >= enemySize.MaxScale)
        {
            animator.SetBool("isVulnerable", true);
            enemyHealth--;
        }

        if (enemyHealth <= 0)
        {
            PlayDeathAnimation();
            playerShoot.AmmunitionCount += bulletsStored + (int)Mathf.Round(bulletsStored * .25f);
            playerSize.IncreasePlayerScale(.1f);
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
