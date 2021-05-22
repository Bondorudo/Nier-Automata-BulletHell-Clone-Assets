using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public int levelID;
    public void SelectLevel()
    {
        SceneManager.LoadScene(levelID);
    }
}
