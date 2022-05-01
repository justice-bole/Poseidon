using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _currentScore = 0;
    //private int updatedScore = 0;
    public int CurrentScore { get { return _currentScore; } }

    private void Update()
    {
        //if(_currentScore < )
        //{
           // _currentScore = updatedScore;
           // print(_currentScore);
       // }
    }



    public void UpdateScore(int scoreIncrement)
    {
        _currentScore += scoreIncrement;
    }
}
