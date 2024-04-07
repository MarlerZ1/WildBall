using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablingOrDisablingLvlPart : MonoBehaviour
{
    [SerializeField] private GameObject newLvlPart;

    private void OnTriggerEnter(Collider other)
    {
        print("activate new area");
        if (other.tag == "Player")
        {
            if (newLvlPart.activeInHierarchy)
                newLvlPart.SetActive(false);
            else
                newLvlPart.SetActive(true);
        }
    }
}
