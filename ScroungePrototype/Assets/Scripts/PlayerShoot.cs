using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    //private int bulletCount = 0;
    private bool canShoot = true;
    private bool isEating = false;
    private Animator animator;

    [SerializeField] private ParticleSystem suctionParticle;
    [SerializeField] private float shootCD = .1f;
    [SerializeField] private float bulletForce = 20f;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            if (isEating) return;
            if (!canShoot) return;
            Shoot();
            StartCoroutine(ShootCooldownCoroutine());
        }

        if(Input.GetButton("Fire2"))
        {
            suctionParticle.Play();
            animator.SetBool("isEating", true);
            isEating = true;
        }
        else
        {
            animator.SetBool("isEating", false);
            isEating = false;  
            suctionParticle.Stop();
        }
    }

    void Shoot()
    {
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        //bulletCount++;
        //print(bulletCount);
    }

    IEnumerator ShootCooldownCoroutine()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCD);
        canShoot = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetButton("Fire2"))
        {
            if (collision.gameObject.CompareTag("Bullet") && isEating)
            {
                collision.transform.position = Vector2.MoveTowards(collision.transform.position, transform.position, 10 * Time.deltaTime);
                //Destroy(collision.gameObject);
            }
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet") && !isEating)
        {
            print("You've been hit!");
        }
    }
}
