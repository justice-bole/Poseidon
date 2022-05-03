using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScreen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IClearable clearable = collision.gameObject.GetComponentInChildren<IClearable>();

        if (clearable != null)
        {
            Debug.Log("Screen Cleared!");
            clearable.Clear();
        }      
    }
}
