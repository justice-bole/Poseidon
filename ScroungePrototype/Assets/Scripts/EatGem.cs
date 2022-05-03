using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatGem : MonoBehaviour, IEdible, IAttractable
{
    private float gemLifeTime;
    private Rigidbody2D rb;
    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        int randomX = Random.Range(-2, 3);
        int randomY = Random.Range(1, 3);
        rb.AddForce(new Vector2(randomX, randomY), ForceMode2D.Impulse);
    }

    public void Attract()
    {

    }

    public void Eat()
    {
        Destroy(gameObject);
        gameManager.GemCount++;
    }

    private void Update()
    {
        gemLifeTime += 1 * Time.deltaTime;
        if(gemLifeTime > 5)
        {
            Destroy(gameObject);
        }
    }

    
}
