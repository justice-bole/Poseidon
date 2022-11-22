using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEat : MonoBehaviour
{
    [SerializeField] private PlayerShoot playerShoot;
    [SerializeField] private int suctionDistance = 10;

    private bool _isEating = false;
    public bool IsEating { get { return _isEating; } }


    private void Update()
    {
        CheckIfEating();
    }

    private void CheckIfEating()
    {
        if (Input.GetMouseButton(0))
        {
            if (_isEating) return;
            if (!playerShoot.CanShoot) return;
        }
        else if (Input.GetMouseButton(1))
        {
            _isEating = true;
        }
        else if (!Input.GetMouseButton(1))
        {
            _isEating = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Attracts bullets towards player when eating and in range
        if (Input.GetButton("Fire2"))
        {
            IAttractable attractable = collision.gameObject.GetComponentInChildren<IAttractable>();
            if (attractable != null && _isEating)
            {
                collision.transform.position = Vector2.MoveTowards(collision.transform.position, transform.position, suctionDistance * Time.deltaTime);
            }
        }
    }
}
