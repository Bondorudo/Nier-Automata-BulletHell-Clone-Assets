using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private AudioManager audioManager;
    public GameObject mainMenu;
    public GameObject levelMenu;


    private void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void SetMainMenu()
    {
        audioManager.ButtonPressAudio();
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
    }

    public void SetLevelMenu()
    {
        audioManager.ButtonPressAudio();
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }
}
