using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float minScale = 0.75f;
    private float maxScale = 1.25f;

    private void Awake()
    {
        spriteRenderer = GameObject.Find("PlayerAnimation").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        FlipSpriteY();
    }

    public void IncreasePlayerScale(float addToScale)
    {
        Vector2 playerScale = transform.localScale;
        if(transform.localScale.x < maxScale)
        {
            transform.localScale = new Vector2(playerScale.x + addToScale, playerScale.y + addToScale);
        }
    }

    public void DecreasePlayerScale(float subFromScale)
    {
        Vector2 playerScale = transform.localScale;
        if (transform.localScale.x > minScale)
        {
            transform.localScale = new Vector2(playerScale.x - subFromScale, playerScale.y - subFromScale);
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
