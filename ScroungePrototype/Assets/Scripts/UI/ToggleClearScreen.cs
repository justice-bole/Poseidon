using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleClearScreen : MonoBehaviour
{
    private GameObject clearScreen;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        clearScreen = GameObject.Find("ClearArea");
        clearScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && gameManager.GemCount > 10)
        {
            StartCoroutine(ClearScreenCoroutine());
            gameManager.GemCount -= 10;
        }
    }

    IEnumerator ClearScreenCoroutine()
    {
        clearScreen.SetActive(true);
        yield return new WaitForSeconds(.1f);
        clearScreen.SetActive(false);
    }
}
