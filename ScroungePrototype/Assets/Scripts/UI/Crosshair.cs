using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Texture2D crosshairSprite;
    void Start()
    {
        Cursor.SetCursor(crosshairSprite, Vector2.zero, CursorMode.ForceSoftware);
    }
}
