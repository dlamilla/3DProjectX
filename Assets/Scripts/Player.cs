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

    [Header("Gravedad")]
    //[SerializeField] private float _gravityMultiplier = 3.0f;
    //private float _gravity = -9.81f;
    //private float _velocity;

    [Header("Salto")]
    [SerializeField] private float _jumpPower;

    [Header("Animaciones")]
    [SerializeField] private Animator _anim;

    [Header("Correr")]
    [SerializeField] private float _timeToStopRunning = 2f;
    [SerializeField] private float _nextTimeToUse = 5f;

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

    [SerializeField] private bool _inicio;
    [SerializeField] private int cont = 0;
    [SerializeField] public bool _map;

    private AudioSource _footSteps;
    //private CharacterController _controller;
    private Rigidbody _rb;
    private Camera _mainCamera;
    private float _timeRunning;
    private float _speedGlobal;
    private float anim;
    private Vector3 _velocity;
    private int contFPS;
    

    private void Awake()
    {
        _footSteps = GetComponent<AudioSource>();
        //_controller = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        _inicio = true;
    }

    // Start is called before the first frame update
    void Start()
    {

        _speedGlobal = _speed;

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

        ApplyRunning();

        ApplyRotacion();
        ApplyGravity();
        ApplyMovement();


    }


    private void FixedUpdate()
    {
        
    }

    private void ApplyRunning()
    {
        //if (Input.GetKey(KeyCode.LeftShift) )
        //{
            //if (_inicio && anim != 0f)
            //{
            //    _anim.SetBool("isRunning", true);
            //    _speed = 35f;
            //    if (_timeRunning < _timeToStopRunning)
            //    {
            //        _timeRunning += Time.deltaTime;

            //    }
            //    else
            //    {
            //        _inicio = false;
            //        _timeRunning = 0f;
            //        _speed = _speedGlobal;
            //        _anim.SetBool("isRunning", false);
            //    }
            //}
            //else
            //{
            //    _inicio = false;
            //    _timeRunning = 0f;
            //    _speed = _speedGlobal;
            //    _anim.SetBool("isRunning", false);
            //}
            
        //}

        if (anim != 0f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("GetKey");
                if (_inicio)
                {
                    _anim.SetBool("isRunning", true);
                    _speed = 30;
                    if (_timeRunning < _timeToStopRunning)
                    {
                        _timeRunning += Time.deltaTime;

                    }
                    else
                    {
                        _inicio = false;
                        _timeRunning = 0f;
                        _speed = _speedGlobal;
                        _anim.SetBool("isRunning", false);
                    }
                }
                else
                {
                    _inicio = false;
                    _timeRunning = 0f;
                    _speed = _speedGlobal;
                    _anim.SetBool("isRunning", false);
                }
            }
        }
        else
        {
            _speed = _speedGlobal;
            _anim.SetBool("isRunning", false);
        }
        

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            cont++;
            if (cont == 1)
            {
                StartCoroutine(LeftShiftRun());
            }
            else
            {
                _speed = _speedGlobal;
                _anim.SetBool("isRunning", false);
                cont = 0;
            }
            
        }
    }


    private void ApplyMovement()  //28 speed
    {
        _velocity = _direction * _speed;
        _velocity.y = _rb.velocity.y;
        _rb.velocity = _velocity;
        //_rb.MovePosition(transform.position + _direction * _speed * Time.deltaTime);
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

    private IEnumerator LeftShiftRun()
    {
        _speed = _speedGlobal;
        _anim.SetBool("isRunning", false);
        yield return new WaitForSeconds(_nextTimeToUse);
        cont = 0;
        _inicio = true;
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
