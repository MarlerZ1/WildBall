using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerInput : MonoBehaviour
{

    [SerializeField, Range(0, 100)] private float speed = 2.0f;
    

    private Controls _controls;
    private Rigidbody _rb;
    // Start is called before the first frame update
    private void Awake()
    {
        _controls = new Controls();
        _rb = GetComponent<Rigidbody>();

        
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveInput = _controls.Move.Moving.ReadValue<Vector2>();
        _rb.AddForce(new Vector3(moveInput.x * speed, 0, moveInput.y * speed));
    }



    private void OnEnable()
    {
        _controls.Enable();
    }
    private void OnDisable()
    {
        _controls.Disable();
    }
}
