using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatOnTriggerStay : MonoBehaviour
{
    private PlayerEat playerEat;

    private void Awake()
    {
        playerEat = GameObject.Find("Player").GetComponent<PlayerEat>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IEdible edible = collision.gameObject.GetComponentInChildren<IEdible>();
        if (edible != null && playerEat.IsEating)
        {
            edible.Eat();
        }
    }
}
