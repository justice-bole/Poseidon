using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    private int _gemCount;
    public int GemCount { get { return _gemCount; } set { _gemCount = value; } }

    private GameObject gemIcon;

    private void Awake()
    {
        gemIcon = GameObject.Find("GemIcon");
    }

    private void Start()
    {
        gemIcon.SetActive(false);
    }

    private void Update()
    {
        if(GemCount >= 10)
        {
            gemIcon.SetActive(true);
        }
        else
        {
            gemIcon.SetActive(false);
        }
    }

}
