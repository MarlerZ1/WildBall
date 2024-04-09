using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class Death : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private string killingObjectTag;
    [SerializeField] private GameOverMenu gameOverMenu;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == killingObjectTag)
        {
            Instantiate(particleSystem, transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
            gameObject.SetActive(false);
            gameOverMenu.GameOver();
        }
    }


}
