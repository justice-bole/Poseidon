using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour, IDamageable, IClearable
{
    [SerializeField] private GameObject deathActor;
    [SerializeField] private GameObject bulletFishPrefab;
 
    private GameObject player;
    private Animator animator;
    private bool mustClear = false;
    private int enemyHealth = 10;
    private int enemySpawnAmount = 20;
    private int bulletsStored;
    private float justHitCD = 0.1f;
    private PlayerShoot playerShoot;
    private Rigidbody2D rb;
    private ScaleManager scaleManager;
    private GemSpawner gemSpawner;
    private EnemyMove enemyMove;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyMove = GetComponent<EnemyMove>();
        gemSpawner = GameObject.Find("GemSpawner").GetComponent<GemSpawner>();
        rb = GetComponent<Rigidbody2D>();
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
        bulletsStored += 1;
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
            //playerShoot.AmmunitionCount += bulletsStored + (int)Mathf.Round(bulletsStored * .25f);
            SpawnBulletFish();
            ScalePlayer();
            Destroy(gameObject);
        }
    }

    private void PlayDeathAnimation()
    {
        var deathAnimation = Instantiate(deathActor, transform.position, Quaternion.identity);
        Destroy(deathAnimation, .7f);
    }

    private void ScalePlayer()
    {
        if (player.transform.localScale.x <= 1.25f)
        {
            scaleManager.ChangeObjectScale(player, .1f);
        }
    }

    private void SpawnBulletFish()
    {
        if (bulletFishPrefab == null) return;
        for (int i = 0; i < enemySpawnAmount; i++)
        {
            var radians = 2 * Mathf.PI / bulletsStored * i;

            var vertical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians);

            var spawnDir = new Vector2(horizontal, vertical);

            var spawnPos = rb.position + spawnDir * .8f;
            var enemy = Instantiate(bulletFishPrefab, spawnPos, Quaternion.identity) as GameObject;
            var enemyRB = enemy.GetComponent<Rigidbody2D>();
            Vector2 lookDir = enemyRB.position - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            enemyRB.rotation = angle;
            enemyRB.AddForce(lookDir * 1000 * Time.deltaTime);
        }
    }

    public void DestroyIfGoingTooFast(Collision2D collision)
    {
        if (enemyMove.LastVelocity.magnitude > 8f)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                IClearable clearable = collision.gameObject.GetComponent<IClearable>();
                if (clearable != null)
                {
                    clearable.Clear();
                }
            }

            Clear();
        }      
    }

    private IEnumerator JustHitCDCoroutine()
    {
        animator.SetBool("justHit", true);
        yield return new WaitForSeconds(justHitCD);
        animator.SetBool("justHit", false);
    }

}
