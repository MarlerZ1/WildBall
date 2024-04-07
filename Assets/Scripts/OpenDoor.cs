using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject interactionHint;


    private Controls _controls;
    private Rigidbody _rb;

    private bool _isPlayerInZone = false;
    private bool _isDoorNotOpened = true;
    private void Awake()
    {
        _controls = ControlsSingletone.GetControls();
        _controls.Interaction.OpenDoor.performed += context => Open();

        _rb = GetComponent<Rigidbody>();
    }

    private void Open()
    {
        if (_isPlayerInZone && _isDoorNotOpened)
        {
            _rb.isKinematic = false;
            _isDoorNotOpened = false;
            interactionHint.SetActive(false);
        }
    }


    private void FixedUpdate()
    {
        if (!_isDoorNotOpened)
        {
            _rb.velocity = (new Vector3(0, -transform.localScale.y, 0));
            if (transform.position.y < -transform.localScale.y)
            {
                _controls.Interaction.OpenDoor.performed -= context => Open();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interactionHint.SetActive(true);
            _isPlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactionHint.SetActive(false);
            _isPlayerInZone = false;
        }
    }
}
