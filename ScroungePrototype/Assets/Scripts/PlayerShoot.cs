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
            if (!canShoot) return;
            Shoot();
            StartCoroutine(ShootCooldownCoroutine());
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
            isEating = true;
            animator.SetBool("isEating", true);
            if (collision.gameObject.CompareTag("Bullet") && isEating)
            {
                Destroy(collision.gameObject);
            }
        }    
        else
        {
            isEating = false;
            animator.SetBool("isEating", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            print("You've been hit!");
        }
    }
}
