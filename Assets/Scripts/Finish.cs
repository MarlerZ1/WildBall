using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private bool isFinish = false;
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.tag == "Player" & !isFinish)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1;
        }
        else if (other.gameObject.tag == "Player")
        {
            GetComponent<ParticleSystem>().Play();
            Time.timeScale = 0;
            winScreen.SetActive(true);
        }
    }
}
