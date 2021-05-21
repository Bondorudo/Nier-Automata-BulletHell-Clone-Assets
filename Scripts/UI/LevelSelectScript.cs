using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public void SelectLevel()
    {
        switch (this.gameObject.name)
        {
            case "TestLevel":
                SceneManager.LoadScene("DefaultScene");
                break;
            case "Level_1_Button":
                SceneManager.LoadScene("Level_1");
                break;
            case "Level_2_Button":
                SceneManager.LoadScene("Level_2");
                break;
            case "Level_3_Button":
                SceneManager.LoadScene("Level_3");
                break;
            case "Level_4_Button":
                SceneManager.LoadScene("Level_4");
                break;
            case "Level_10_Button":
                SceneManager.LoadScene("Level_10");
                break;
        }
    }
}
