using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    [SerializeField] private PlayerEat playerEat;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private float shootCD = .1f;

    private bool _canShoot = true;
    public bool CanShoot { get { return _canShoot; } }
 

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if (playerEat.IsEating) return;
            if (!_canShoot) return;
            Shoot();
            StartCoroutine(ShootCooldownCoroutine());
        }  
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    private IEnumerator ShootCooldownCoroutine()
    {
        _canShoot = false;
        yield return new WaitForSeconds(shootCD);
        _canShoot = true;
    }

}
