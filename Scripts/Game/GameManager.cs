using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    private UI_Script uiScript;

    private bool pauseGame;

    
    private void Start()
    {
        uiScript = GameObject.FindWithTag("GameManager").GetComponent<UI_Script>();
        pauseGame = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E))
        {
            pauseGame = true;
            uiScript.PauseMenu();
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
        uiScript.Victory();
    }

    public void GameOver()
    {
        player.SetActive(false);
        pauseGame = true;
        uiScript.GameOver();
    }

    public void NextLevelButton()
    {
        player.SetActive(true);
        uiScript.NextLevelButton();
    }

    public void ContinueButton()
    {
        pauseGame = false;
        uiScript.ContinueButton();
    }
    public void RestartButton()
    {
        player.SetActive(true);
        uiScript.RestartButton();
    }

    public void QuitToMenu()
    {
        uiScript.QuitToMenu();
    }
}
