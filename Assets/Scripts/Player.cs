using System;
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

    [Header("Salto")]
    [SerializeField] private float _jumpPower;

    [Header("Animaciones")]
    [SerializeField] public Animator _anim;

    [Header("Correr")]   
    [SerializeField] private float _speedExtra;
    [SerializeField] private float _timeRunning;
    private float _timeCurrentRunning;
    private float _timeNextRunning;
    [SerializeField] private float _timeBetweenRun;
    private bool _canRun = true;
    private bool _isRunning = false;
    private float _speedBase;


    [Header("Materiales")]
    [SerializeField] private Texture m_MainTexture1;
    [SerializeField] private Texture m_MainTexture2;
    [SerializeField] private Texture m_MainTexture3;
    [SerializeField] private Renderer m_Renderer;

    //[SerializeField] private Transform _starPosition;

    [Header("FPS")]
    [SerializeField] private Transform _camFPS;
    [SerializeField] private GameObject _firstPerson;
    [SerializeField] private GameObject _cameraFPS;

    [Header("ThirdPerson")]
    [SerializeField] private GameObject _cameraThird;
    [SerializeField] public bool _FisrtToThird;
    [SerializeField] public bool _map;

    private AudioSource _footSteps;
    //private CharacterController _controller;
    private Rigidbody _rb;
    private Camera _mainCamera;
    public float anim;
    private Vector3 _velocity;
    private int contFPS;
    

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
        _speedBase = _speed;
        _timeCurrentRunning = _timeRunning;
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        anim = _input.magnitude;
        if (anim > 0f)
        {
            _footSteps.enabled = true;
        }
        else
        {
            _footSteps.enabled = false;
        }
        
        _anim.SetFloat("Speed", Mathf.Abs(anim));
        _direction = new Vector3(_input.x, 0.0f, _input.y).normalized;

        ChangePOV();
        ApplyRunning();
        ApplyRotacion();
    }


    private void FixedUpdate()
    {
        ApplyMovement(_direction);
    }

    private void ChangePOV(){
        if (Input.GetKeyDown(KeyCode.V))
        {
            contFPS++;
            if (contFPS == 1)
            {
                _FisrtToThird = true;
                _cameraFPS.SetActive(true);
                _firstPerson.SetActive(false);
                _cameraThird.SetActive(false);
            }
            else
            {
                _FisrtToThird = false;
                _cameraFPS.SetActive(false);
                _firstPerson.SetActive(true);
                _cameraThird.SetActive(true);
                contFPS = 0;
            }
        }

        if (_FisrtToThird)
        {
            transform.rotation = Quaternion.Euler(0f, _camFPS.rotation.eulerAngles.y, 0f);
        }
    }

    private void ApplyRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canRun)
        {
            _speed = _speedExtra;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = _speedBase;
            _isRunning = false;
            _anim.SetBool("isRunning",false);
        }

        if (Mathf.Abs(anim) >= 0.1f && _isRunning)
        {
            if (_timeCurrentRunning > 0)
            {
                _anim.SetBool("isRunning",true);
                _timeCurrentRunning -= Time.deltaTime;
                
            }else
            {
                _anim.SetBool("isRunning",false);
                _speed = _speedBase;
                _isRunning = false;
                _canRun = false;
                _timeNextRunning = Time.time + _timeBetweenRun;
            }
        }

        if (!_isRunning && _timeCurrentRunning <= _timeRunning && Time.time >= _timeNextRunning)
        {
            _timeCurrentRunning += Time.deltaTime;
            if (_timeCurrentRunning >= _timeRunning)
            {
                _canRun = true;
            }
        }
    }


    private void ApplyMovement(Vector3 dirPlayer)  //28 speed
    {
        _velocity = dirPlayer * _speed;
        _velocity.y = _rb.velocity.y;
        _rb.velocity = _velocity;
        //_rb.MovePosition(transform.position + _direction * _speed * Time.deltaTime);
        //_controller.Move(_direction * _speed * Time.deltaTime);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemigo cerca");
            m_Renderer.material.SetTexture("_MainTex", m_MainTexture2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Adios");
            m_Renderer.material.SetTexture("_MainTex", m_MainTexture1);
        }
    }


    public void MoveToStart()
    {
        //transform.position = _starPosition.position;
    }

    public void DefaultRenderer()
    {
        m_Renderer.material.SetTexture("_MainTex", m_MainTexture1);
    }

}
