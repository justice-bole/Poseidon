using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySize : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float _maxScale = 2;
    public float MaxScale { get { return _maxScale; } }
    private float scaleIncrement = 0.01f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ScaleUpEnemy()
    {
        Vector2 enemyScale = transform.localScale;
        if (enemyScale.x < _maxScale)
        {
            transform.localScale = new Vector2(enemyScale.x + scaleIncrement, enemyScale.y + scaleIncrement);
        }
    }

}
