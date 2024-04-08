using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Image pauseBtnImage;

    [SerializeField] private Sprite playingModeSprite;
    [SerializeField] private Sprite pauseModeSprite;

    [SerializeField] private GameObject pauseMenu;
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

    public void ChangePauseState()
    {
        if (Time.timeScale == 0)
        {
            pauseBtnImage.sprite = playingModeSprite;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseBtnImage.sprite = pauseModeSprite;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void RestartLvl()
    {
        StartNewLvl(SceneManager.GetActiveScene().buildIndex);
    }
}
