using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private bool _isAlreadyPlayer = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_isAlreadyPlayer)
        {
            _isAlreadyPlayer = true;
            GetComponent<ParticleSystem>().Play();
            GetComponent<Animator>().SetBool("isPickUp", true);
        }
    }

    public void OnParticleSystemStopped()
    {
        Destroy(transform.parent.gameObject);
    }


}
