using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleManager : MonoBehaviour
{
    public void ChangeObjectScale(GameObject objectToScale, float addToScale)
    {
        var scale = objectToScale.transform.localScale;
        objectToScale.transform.localScale = new Vector2(scale.x + addToScale, scale.y + addToScale);
    }

}
