using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Velocidad Mov")]
    [SerializeField] private float _speed = 5f;
    private Vector2 _input;
    private Vector3 _direction;

    [Header("Rotacion")]
    [SerializeField] private float _rotationSpeed = 500f;

    [Header("Gravedad")]
    //[SerializeField] private float _gravityMultiplier = 3.0f;
    //private float _gravity = -9.81f;
    //private float _velocity;

    [Header("Salto")]
    [SerializeField] private float _jumpPower;

    [Header("Animaciones")]
    [SerializeField] private Animator _anim;

    private AudioSource _footSteps;
    //private CharacterController _controller;
    private Rigidbody _rb;
    private Camera _mainCamera;



    private void Awake()
    {
        _footSteps = GetComponent<AudioSource>();
        //_controller = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        float anim = _input.magnitude;
        if (anim > 0f)
        {
            _footSteps.enabled = true;
        }
        else
        {
            _footSteps.enabled = false;
        }
        _anim.SetFloat("Speed", Mathf.Abs(anim));
        _direction = new Vector3(_input.x, 0.0f, _input.y);

        ApplyRotacion();
        ApplyGravity();
        ApplyMovement();


    }

    private void ApplyMovement()
    {
        

        _rb.MovePosition(transform.position + _direction * _speed * Time.deltaTime);
        //_controller.Move(_direction * _speed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        //if (IsGrounded() && _velocity < 0.0f)
        //{
        //    _velocity = -1.0f;
        //}
        //else
        //{
        //    _velocity += _gravity * _gravityMultiplier * Time.deltaTime;
        //}
        
        //_direction.y = _velocity;
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

    
}
