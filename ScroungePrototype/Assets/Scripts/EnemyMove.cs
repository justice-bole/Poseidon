using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private bool isMovementInverted = false;
    private bool positiveXMovement = true;
    private Rigidbody2D rb;
  
 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(transform.position.x > 8.25f)
        {
            positiveXMovement = false;
        }
        else if(transform.position.x < - 8.1)
        {
            positiveXMovement = true;
        }
    }

    private void FixedUpdate()
    {
        if(!isMovementInverted)
        {
            FixedMove();
        }
        else
        {
            InvertMoveDirection();
        }
        
    }

    private void FixedMove()
    {
        float randomNumber = Random.Range(0f, 5f);
        Vector2 vector2 = new Vector2(randomNumber, randomNumber);

        if(positiveXMovement)
        {
            rb.AddForce(vector2, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(vector2, ForceMode2D.Force);
        }
    }

    private void InvertMoveDirection()
    {
        rb.AddForce(new Vector2(Random.Range(-1f, 5f), Random.Range(-1f, -5f)), ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isMovementInverted)
        {
            isMovementInverted = true;
        }
        else
        {
            isMovementInverted = false;
        }
    }
}
