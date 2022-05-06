using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleClearScreen : MonoBehaviour
{
    //This script is seperated from "ClearScreen" because this script stores data when ClearScreen is turned off via clearScreen.SetActive(false)

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
    }

    private void RequestToClearScreen()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.GemCount >= 10)
        {
            ClearGameScreen();
        }
    }

    private void ClearGameScreen()
    {

        StartCoroutine(ClearScreenCoroutine());
        gameManager.GemCount -= 10;

    }

    IEnumerator ClearScreenCoroutine()
    {
        clearScreen.SetActive(true);
        yield return new WaitForSeconds(.1f);
        clearScreen.SetActive(false);
    }
}
