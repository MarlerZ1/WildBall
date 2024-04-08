using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private string killingObjectTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == killingObjectTag)
        {
            Instantiate(particleSystem, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }


}
