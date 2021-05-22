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
    private EnemyManager heartManager;
    private LevelHeart levelHeart;
    private AreAllEnemiesDead areEnemiseDead;

    private bool pauseGame;
    public bool isGameOver;
    
    private void Start()
    {
        player.SetActive(true);
        uiScript = GameObject.FindWithTag("GameManager").GetComponent<UI_Script>();
        heartManager = GameObject.FindWithTag("WinCondition").GetComponent<EnemyManager>();
        levelHeart = GameObject.FindWithTag("WinCondition").GetComponent<LevelHeart>();
        areEnemiseDead = GameObject.FindWithTag("GameManager").GetComponent<AreAllEnemiesDead>();
        pauseGame = false;
        isGameOver = false;
    }

    void Update()
    {
        PauseGame();
        CheckCanHeartTakeDamage();
        CheckVictory();
    }

    public void CheckCanHeartTakeDamage()
    {
        if (areEnemiseDead.AreTheyDestroyed())
        {
            levelHeart.CanTakeDamage();
            levelHeart.SetVulnerableColor();
        }
    }

    public void CheckVictory()
    {
        int enemyHealth = heartManager.CurrentHealth();
        if (enemyHealth == 0)
        {
            Victory();
        }
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
        uiScript.NextLevelButton();
    }

    public void ContinueButton()
    {
        pauseGame = false;
        uiScript.ContinueButton();
    }
    public void RestartButton()
    {
        uiScript.RestartButton();
    }

    public void QuitToMenu()
    {
        uiScript.QuitToMenu();
    }
}
