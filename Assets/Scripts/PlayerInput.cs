using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerInput : MonoBehaviour
{

    [SerializeField, Range(0, 100)] private float speed = 2.0f;
    [SerializeField] private float jumpForce;

    private Controls _controls;
    private Rigidbody _rb;
    private bool _isGrounded = true;
    // Start is called before the first frame update
    private void Awake()
    {
        _controls = ControlsSingletone.GetControls();
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveInput = _controls.Move.Moving.ReadValue<Vector2>();
        _rb.AddForce(new Vector3(moveInput.x, 0, moveInput.y).normalized * speed);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }

    private void OnEnable()
    {
        _controls.Enable();
        _controls.Move.Jump.performed += context => Jump();
    }
    private void OnDisable()
    {
        _controls.Move.Jump.performed -= context => Jump();
        _controls.Disable();
    }

    private void OnDestroy()
    {
        ControlsSingletone.ResetControls();
    }
}
