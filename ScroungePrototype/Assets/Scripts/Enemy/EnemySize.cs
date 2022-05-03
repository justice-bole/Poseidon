using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySize : MonoBehaviour
{
    private float _maxScale = 1.5f;
    public float MaxScale { get { return _maxScale; } }

    private void Awake()
    {
    }

    public void ScaleUpEnemy(float scaleIncrement)
    {
        Vector2 enemyScale = transform.localScale;
        if (enemyScale.x < _maxScale)
        {
            transform.localScale = new Vector2(enemyScale.x + scaleIncrement, enemyScale.y + scaleIncrement);
        }
    }

}
