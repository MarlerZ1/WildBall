using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartNewLvl(int lvl)
    {
        SceneManager.LoadScene(lvl);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

}
