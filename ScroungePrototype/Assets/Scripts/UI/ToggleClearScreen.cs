using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleClearScreen : MonoBehaviour
{
    //This script is seperated from "ClearScreen" because this script stores data when ClearScreen is turned off via clearScreen.SetActive(false)

    
    [SerializeField] private int _fishNeededToClearScreen;

    public Slider clearScreenSlider;
    public int FishNeededToClearScreen { get { return _fishNeededToClearScreen; } }

    private float clearScreenDuration = 0.1f;
    private GameObject clearScreen;
    private GameManager gameManager;
    

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        clearScreen = GameObject.Find("ClearArea");
        clearScreen.SetActive(false);
    }

    void Update()
    {
        RequestToClearScreen();
        UpdateClearUI();
    }

    private void RequestToClearScreen()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.GemCount >= _fishNeededToClearScreen)
        {
            ClearGameScreen();
        }
    }

    private void ClearGameScreen()
    {

        StartCoroutine(ClearScreenCoroutine());
        gameManager.GemCount = 0;

    }

    private void UpdateClearUI()
    {
        clearScreenSlider.value = (float)gameManager.GemCount / (float)FishNeededToClearScreen;
    }

    IEnumerator ClearScreenCoroutine()
    {
        clearScreen.SetActive(true);
        yield return new WaitForSeconds(clearScreenDuration);
        clearScreen.SetActive(false);
    }
}
