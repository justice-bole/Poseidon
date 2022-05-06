using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    private GameObject gameOverScreen;


    private void Awake()
    {
        gameOverScreen = GameObject.Find("GameOverScreen");
    }

    private void Start()
    {
        if(gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    private void StartTime()
    {
        Time.timeScale = 1;
    }

    public void EnableGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartTime();
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
