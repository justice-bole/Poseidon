using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject largeBulletPrefab;
    public Transform firePoint;

    [SerializeField] private PlayerEat playerEat;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private float shootCD = .6f;

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
        playerSize = GameObject.Find("PlayerSprite").GetComponent<PlayerSize>();
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
    }

    private void Shoot()
    {
        if(bulletCount % 20 == 0)
        {
            playerSize.DecreasePlayerScale();
        }

        if (bulletCount % 2 == 0)
        {
            LargeShot();
        }
        else
        {
            Vector3 bulletOffset = new Vector3(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position + bulletOffset, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
            StartCoroutine(ShootCooldownCoroutine());

            bulletCount++;
            _ammunitionCount--;
            print(_ammunitionCount);
        }

    }

    private IEnumerator ShootCooldownCoroutine()
    {
        _canShoot = false;
        yield return new WaitForSeconds(shootCD);
        _canShoot = true;
    }

    private void LargeShot()
    {
        GameObject largeBullet = Instantiate(largeBulletPrefab, firePoint.position, firePoint.rotation);
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
        if(_ammunitionCount > 750)
        {
            shootCD = 0.01f;
        }
        else if(_ammunitionCount < 750 && _ammunitionCount > 500)
        {
            shootCD = .04f;
        }
        else if(_ammunitionCount < 500 && _ammunitionCount > 250)
        {
            shootCD = .06f;
        }
        else
        {
            shootCD = .1f;
        }
    }

}
