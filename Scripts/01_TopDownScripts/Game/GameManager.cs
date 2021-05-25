using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private AudioManager audioManager;
    private UI_Script uiScript;

    private bool pauseGame;
    public bool isGameOver;
    
    private void Start()
    {
        player.SetActive(true);
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        uiScript = GameObject.FindWithTag("GameManager").GetComponent<UI_Script>();
        pauseGame = false;
        isGameOver = false;
    }

    void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (!isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E))
            {
                pauseGame = true;
                uiScript.PauseMenu();
            }
        }
        if (pauseGame == true)
        {
            Time.timeScale = 0;
        }
        else if (pauseGame == false)
        {
            Time.timeScale = 1;
        }
    }

    public void PauseMenu()
    {
        pauseGame = true;
        uiScript.PauseMenu();
    }

    public void Victory()
    {
        pauseGame = true;
        isGameOver = true;
        uiScript.Victory();
    }

    public void GameOver()
    {
        player.SetActive(false);
        isGameOver = true;
        pauseGame = true;
        uiScript.GameOver();
    }

    public void NextLevelButton()
    {
        audioManager.ButtonPressAudio();
        uiScript.NextLevelButton();
    }

    public void ContinueButton()
    {
        audioManager.ButtonPressAudio();
        pauseGame = false;
        uiScript.ContinueButton();
    }
    public void RestartButton()
    {
        audioManager.ButtonPressAudio();
        uiScript.RestartButton();
    }

    public void QuitToMenu()
    {
        uiScript.QuitToMenu();
    }
}
