using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem suctionParticle;
    private Animator animator;
    private PlayerEat playerEat;

    private void Awake()
    {
        animator = GameObject.Find("PlayerAnimation").GetComponent<Animator>();
        playerEat = GameObject.Find("Player").GetComponent<PlayerEat>();
    }

    private void Update()
    {
        SetAnimationState();
    }

    private void SetAnimationState()
    {
        if (animator == null) return;
        if (playerEat.IsEating)
        {
            animator.SetBool("isEating", true);
            suctionParticle.Play();
        }
        else
        {
            animator.SetBool("isEating", false);
            suctionParticle.Stop(); // this seems bugged
        }

    }
}
