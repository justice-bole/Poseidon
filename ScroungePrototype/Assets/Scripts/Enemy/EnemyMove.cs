using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2;
    private Rigidbody2D rb;
    private EnemyHit hit;
    public Vector2 LastVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hit = GetComponent<EnemyHit>();
        
        int randomNumber = Random.Range(0, 3);

        switch (randomNumber)
        {
            case 0:
                rb.velocity = new Vector2(-1, -1) * movementSpeed;
                break;
            case 1:
                rb.velocity = new Vector2(1, -1) * movementSpeed;
                break;
            case 2:
                rb.velocity = new Vector2(-1, 1) * movementSpeed;
                break;
            default:
                rb.velocity = new Vector2(1, 1) * movementSpeed;
                break;
        }
    }

    private void FixedUpdate()
    {
        LastVelocity = rb.velocity;
        var speed = LastVelocity.magnitude;
        var direction = new Vector2(LastVelocity.normalized.x, LastVelocity.normalized.y);
        rb.velocity = direction * Mathf.Max(speed, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy"))
        {
            hit.DestroyIfGoingTooFast(collision);
            var speed = LastVelocity.magnitude;
            var direction = Vector2.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
            print(speed);
        } 
    }

}
