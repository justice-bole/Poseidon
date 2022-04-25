using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour, IDamageable
{
    private GameObject gameOverScreen;
    private int playerHealth = 3;
    private GameObject player;
    private PlayerEat playerEat;

    private void Awake()
    {
        gameOverScreen = GameObject.Find("GameOverScreen");
        player = GameObject.Find("Player");
        playerEat = player.GetComponent<PlayerEat>();
       
    }

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
        DestroyPlayer();
    }

    public void Damage()
    {
        if (playerEat.IsEating) return;
        playerHealth--;
    }

    private void DestroyPlayer()
    {
        if(player == null) return;
        if(playerHealth <= 0)
        {
            Destroy(player);
            StopTime();
            EnableGameOverScreen();
        }
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }

    private void StartTime()
    {
        Time.timeScale = 1;
    }

    private void EnableGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartTime();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

}
