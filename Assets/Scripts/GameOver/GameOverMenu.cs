using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
    }

    public void StartNewLvl(int lvl)
    {
        SceneManager.LoadScene(lvl);
        Time.timeScale = 1;
    }
    public void RestartLvl()
    {
        StartNewLvl(SceneManager.GetActiveScene().buildIndex);
    }

}
