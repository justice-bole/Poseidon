using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleClearScreen : MonoBehaviour
{
    private GameObject clearScreen;
    // Start is called before the first frame update
    void Start()
    {
        clearScreen = GameObject.Find("ClearArea");
        clearScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ClearScreenCoroutine());
        }
    }

    IEnumerator ClearScreenCoroutine()
    {
        clearScreen.SetActive(true);
        yield return new WaitForSeconds(.1f);
        clearScreen.SetActive(false);
    }
}
