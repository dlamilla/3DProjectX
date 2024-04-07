using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Velocidad Mov")]
    [SerializeField] private float _speed = 5f;
    private Vector2 _input;
    private Vector3 _direction;

    [Header("Rotacion")]
    [SerializeField] private float _rotationSpeed = 500f;

    [Header("Gravedad")]
    [SerializeField] private float _gravityMultiplier = 3.0f;
    private float _gravity = -9.81f;
    private float _velocity;

    [Header("Salto")]
    [SerializeField] private float _jumpPower;

    private CharacterController _controller;
    private Camera _mainCamera;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //Hide curser
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        //Activate mouse
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        ApplyRotacion();
        ApplyGravity();
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        _controller.Move(_direction * _speed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * _gravityMultiplier * Time.deltaTime;
        }
        
        _direction.y = _velocity;
    }

    private void ApplyRotacion()
    {
        if (_input.sqrMagnitude == 0)
        {
            return;
        }

        _direction = Quaternion.Euler(0.0f, _mainCamera.transform.eulerAngles.y, 0.0f) * new Vector3(_input.x, 0.0f, _input.y);
        var targetRotation = Quaternion.LookRotation(_direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    public void MovPlayer(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>().normalized;
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    public void JumpPlayer(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }

        if (!IsGrounded())
        {
            return;
        }

        _velocity += _jumpPower;
    }

    private bool IsGrounded() => _controller.isGrounded;
}
