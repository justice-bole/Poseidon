using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2;
    private Rigidbody2D rb;
    private Vector2 lastVelocity;
    private bool positiveXMovement = true;
    private bool positiveYMovement = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        int randomNumber = Random.Range(0, 3);

        switch (randomNumber)
        {
            case 0:
                rb.velocity = new Vector2(-1, -1) * movementSpeed;
                positiveXMovement = false;
                positiveYMovement = false;
                break;
            case 1:
                rb.velocity = new Vector2(1, -1) * movementSpeed;
                positiveXMovement = true;
                positiveYMovement = false;
                break;
            case 2:
                rb.velocity = new Vector2(-1, 1) * movementSpeed;
                positiveXMovement = false;
                positiveYMovement = true;
                break;
            default:
                rb.velocity = new Vector2(1, 1) * movementSpeed;
                positiveXMovement = true;
                positiveYMovement = true;
                break;
        }
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
        var speed = lastVelocity.magnitude;
        var direction = new Vector2(lastVelocity.normalized.x, lastVelocity.normalized.y);
        rb.velocity = direction * Mathf.Max(speed, 2f);
        
        //CalculateXDirection();
        //CalculateYDirection();
        //TransformPosition();
    }

    void CalculateYDirection()
    {
        if (transform.position.y > 3.8f)
        {
            positiveYMovement = false;
        }
        else if (transform.position.y < -3.8)
        {
            positiveYMovement = true;
        }
    }

    void CalculateXDirection()
    {
        if (transform.position.x > 8.25f)
        {
            positiveXMovement = false;
        }
        else if (transform.position.x < -8.1)
        {
            positiveXMovement = true;
        }
    }

    private void TransformPosition()
    {
        if (positiveYMovement && positiveXMovement)
        {
            transform.Translate((Vector2.right + Vector2.up) * movementSpeed * Time.deltaTime);
        }
        else if (!positiveYMovement && positiveXMovement)
        {
            transform.Translate((Vector2.right - Vector2.up) * movementSpeed * Time.deltaTime);
        }
        else if (positiveYMovement && !positiveXMovement)
        {
            transform.Translate((-Vector2.right + Vector2.up) * movementSpeed * Time.deltaTime);
        }
        else if (!positiveYMovement && !positiveXMovement)
        {
            transform.Translate((-Vector2.right - Vector2.up) * movementSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy"))
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
        } 
    }



}
