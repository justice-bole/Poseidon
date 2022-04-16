using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _currentTime = 0;
    public float CurrentTime { get { return _currentTime; } }

    private void Update()
    {
        IncrementTime();
    }

    private void IncrementTime()
    {
        _currentTime += (1 * Time.deltaTime);
        //print(_currentTime.ToString("#.00"));
    }
}
