using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    private AudioManager audioManager;
    public int levelID;


    private void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void SelectLevel()
    {
        audioManager.ButtonPressAudio();
        SceneManager.LoadScene(levelID);
    }
}
