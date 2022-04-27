using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewControls : MonoBehaviour
{
    private GameObject titleScreenUI;
    private GameObject controlsScreenUI;
    private void Awake()
    {
        titleScreenUI = GameObject.Find("TitleScreenUI");
        controlsScreenUI = GameObject.Find("ControlsScreenUI");

    }

    private void Start()
    {
        controlsScreenUI.SetActive(false);
    }

    public void ShowTitleScreen()
    {
        if (titleScreenUI != null)
        {
            titleScreenUI.SetActive(true);
        }
    }

    public void HideTitleScreen()
    {
        if (titleScreenUI != null)
        {
            titleScreenUI.SetActive(false);
        }
    }

    public void ShowControlsScreen()
    {
        if(controlsScreenUI != null)
        {
            controlsScreenUI.SetActive(true);
            HideTitleScreen();
        }
    }

    public void HideControlsScreen()
    {
        if(controlsScreenUI != null)
        {
           controlsScreenUI.SetActive(false);
            ShowTitleScreen();
        }
    }    


}
