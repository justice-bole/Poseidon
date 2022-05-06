using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject largeBulletPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private PlayerEat playerEat;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private float shootCD = .6f;

    private Animator animator;
    private PlayerSize playerSize;
    private int bulletCount = 0;
    private int _ammunitionCount = 500;

    public int AmmunitionCount
    {
        get
        {
            return _ammunitionCount;
        }
        set
        {
            if (value > 1000)
            {
                _ammunitionCount = 1000;
            }
            else if (value < 0)
            {
                _ammunitionCount = 0;
            }
            else
            {
                _ammunitionCount = value;
            }
        }
    }

    private bool _canShoot = true;
    public bool CanShoot { get { return _canShoot; } }

    private void Awake()
    {
        animator = GameObject.Find("PlayerAnimation").GetComponent<Animator>();
        playerSize = GetComponent<PlayerSize>();
    }

    private void Update()
    {
        RequestingShoot();
        ResetBulletCount();
    }

    private void RequestingShoot()
    {
        if (Input.GetMouseButton(0))
        {
            if (playerEat.IsEating) return;
            if (!_canShoot) return;
            if (_ammunitionCount <= 0) return;
            CalculateShotCooldown();
            Shoot();
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }

    private void Shoot()
    {
        animator.SetBool("isShooting", true);
        if (bulletCount % 20 == 0)
        {
            playerSize.DecreasePlayerScale(0.05f);
        }
        Vector3 bulletOffset = new Vector3(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position + bulletOffset, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        StartCoroutine(ShootCooldownCoroutine());

        bulletCount++;
        _ammunitionCount--;
    }

    private IEnumerator ShootCooldownCoroutine()
    {
        _canShoot = false;
        yield return new WaitForSeconds(shootCD);
        _canShoot = true;
    }

    private void LargeShot()
    {
        Vector3 bulletOffset = new Vector3(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        GameObject largeBullet = Instantiate(largeBulletPrefab, firePoint.position + bulletOffset, firePoint.rotation);
        Rigidbody2D rb = largeBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        StartCoroutine(ShootCooldownCoroutine());

        bulletCount++;
        _ammunitionCount--;
        print(_ammunitionCount);
    }

    private void ResetBulletCount()
    {
        if (bulletCount > 1000)
            bulletCount = 0;
    }

    private void CalculateShotCooldown()
    {
        if (_ammunitionCount > 750)
        {
            shootCD = 0.02f;
        }
        else if (_ammunitionCount < 750 && _ammunitionCount > 500)
        {
            shootCD = .08f;
        }
        else if (_ammunitionCount < 500 && _ammunitionCount > 250)
        {
            shootCD = .12f;
        }
        else
        {
            shootCD = .20f;
        }
    }

}
