using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GameOverTrigger : MonoBehaviour
{
   //This class is depricated. Used to complete the skillbox task
    [SerializeField] private GameOverMenu gameOverMenu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameOverMenu.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOverMenu.GameOver();
        }
    }
}
