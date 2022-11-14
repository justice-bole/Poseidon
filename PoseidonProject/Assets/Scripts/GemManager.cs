using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager : MonoBehaviour, IEdible, IAttractable
{
    [SerializeField] private float maxGemLifetime = 10f;
    private float gemLifeTime;
    private Rigidbody2D rb;
    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        ImpulseGem();
    }

    private void Update()
    {
        IncrementGemLifetime();
        DestroyOldGems();
    }

    public void Attract()
    {
        //this is needed (even empty) for PlayerEat to attract the gem
    }

    public void Eat()
    {
        Destroy(gameObject);
        gameManager.GemCount++;
    }

    private void ImpulseGem()
    {
        int randomX = Random.Range(-2, 3);
        int randomY = Random.Range(1, 3);
        rb.AddForce(new Vector2(randomX, randomY), ForceMode2D.Impulse);
    }

    private void DestroyOldGems()
    {
        if (gemLifeTime > maxGemLifetime)
        {
            Destroy(gameObject);
        }
    }

    private void IncrementGemLifetime()
    {
        gemLifeTime += 1 * Time.deltaTime;
    }
}
