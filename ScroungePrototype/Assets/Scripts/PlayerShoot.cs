using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    private bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(canFire)
            {
                Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                StartCoroutine(BulletCooldownCoroutine());
            }
            
        }
       
    }

    IEnumerator BulletCooldownCoroutine()
    {
        canFire = false;
        yield return new WaitForSeconds(.25f);
        canFire = true;
    }
}
