using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEat : MonoBehaviour
{

    private Animator animator;
    private bool _isEating = false;
    public bool IsEating { get { return _isEating; } }

    private int suctionDistance = 10;
  
    [SerializeField] private ParticleSystem suctionParticle;
    [SerializeField] private PlayerShoot playerShoot;


    private void Awake()
    {
        animator = GameObject.Find("PlayerAnimation").GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerAnimationState();
    }

    private void PlayerAnimationState()
    {
        if (Input.GetMouseButton(0))
        {
            if (_isEating) return;
            if (!playerShoot.CanShoot) return;
        }
        else if (Input.GetMouseButton(1))
        {
            //animator.SetBool("isEating", true);
            _isEating = true;
        }
        else if (!Input.GetMouseButton(1))
        {
            //animator.SetBool("isEating", false);
            _isEating = false;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            suctionParticle.Play();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            suctionParticle.Stop();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Attracts bullets towards player when eating and in range
        if (Input.GetButton("Fire2"))
        {
            if (collision.gameObject.CompareTag("Bullet") && _isEating)
            {
                collision.transform.position = Vector2.MoveTowards(collision.transform.position, transform.position, suctionDistance * Time.deltaTime);
            }
        }
    }
}
