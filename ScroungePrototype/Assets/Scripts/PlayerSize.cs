using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float scaleMultiplier = .01f;
    private float minScale = 0.75f;
    private float maxScale = 1.25f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        FlipSpriteY();
    }

    public void IncreasePlayerScale()
    {
        Vector2 playerScale = transform.localScale;
        if(transform.localScale.x < maxScale)
        {
            transform.localScale = new Vector2(playerScale.x + scaleMultiplier, playerScale.y + scaleMultiplier);
        }
    }

    public void DecreasePlayerScale()
    {
        Vector2 playerScale = transform.localScale;
        if (transform.localScale.x > minScale)
        {
            transform.localScale = new Vector2(playerScale.x - scaleMultiplier, playerScale.y - scaleMultiplier);
        }
    }

    private void FlipSpriteY() //prevent sprite from swimming on its back
    {
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }


}
