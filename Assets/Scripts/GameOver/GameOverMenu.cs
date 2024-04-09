using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private float timeWait;
    public void GameOver()
    {
        StartCoroutine(IEGameOver());
    }

    private IEnumerator IEGameOver()
    {
        yield return new WaitForSecondsRealtime(timeWait);
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
