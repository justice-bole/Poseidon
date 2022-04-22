using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D crosshairSprite;
    void Start()
    {
        //Cursor.visible = false;
        Cursor.SetCursor(crosshairSprite, Vector2.zero, CursorMode.ForceSoftware);
    }
}
