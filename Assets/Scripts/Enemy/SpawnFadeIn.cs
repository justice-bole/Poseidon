using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFadeIn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private SpriteRenderer spriteRenderer;
    private float transparencyIncrement = .1f;
    private float startingTransparency = .5f;
    private Color spriteColor;
    private Vector2 playerScale;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColor = GetComponent<SpriteRenderer>().color;
    }

    private void Start()
    {
        playerScale = transform.localScale;
        spriteColor.a = startingTransparency;
        spriteRenderer.color = spriteColor;
    }

    private void Update()
    {
        IncreaseTransparency();
    }
    private void IncreaseTransparency()
    {
        if (spriteColor != null)
        {
            if(spriteColor.a < 1)
            {
                StartCoroutine(TransparencyIncrementCoroutine());
            }  
            else
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }   
    }


    IEnumerator TransparencyIncrementCoroutine()
    {
        yield return new WaitForSeconds(.1f);
        spriteColor.a += .1f * Time.deltaTime;
        spriteRenderer.color = spriteColor;
        playerScale.x += .1f * Time.deltaTime;
        playerScale.y += .1f * Time.deltaTime;    
        transform.localScale = playerScale;
    }
}
