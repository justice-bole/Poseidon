using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScreen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IClearable clearable))
        {
            clearable.Clear();
        }
    }
}
