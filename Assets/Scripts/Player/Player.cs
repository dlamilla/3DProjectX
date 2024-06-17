using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Velocidad Mov")]
    [SerializeField] private float _speed = 5f;
    private Vector2 _input;
    private Vector3 _direction;
    public bool canMove = true;
    public float anim;

    [Header("Rotacion")]
    [SerializeField] private float _rotationSpeed = 500f;

    [Header("RayCast")]
    [SerializeField] private Transform _camera;
    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _layerInterac;
    [SerializeField] private GameObject _interact;
    [SerializeField] public bool canPickUpMap = false;
    [SerializeField] public bool canPickUpItem = false;


    [Header("Correr")]
    [SerializeField] private float _speedExtra;
    [SerializeField] private float _timeRunning;
    [SerializeField] private float _timeBetweenRun;
    [SerializeField] private float run;
    [SerializeField] private float runMax;
    [SerializeField] private Image runStatus;
    public bool _canRun = true;
    public bool _isRunning = false;
    private float _speedBase;
    private float _timeCurrentRunning;
    private float _timeNextRunning;

    [Header("FPS")]
    [SerializeField] private Transform _camFPS;

    [Header("ThirdPerson")]
    [SerializeField] public bool _FisrtToThird;
    [SerializeField] public bool _map;

    [Header("Sounds")]
    [SerializeField] private AudioClip _walkPlayer;
    [SerializeField] private AudioClip _runPlayer;

    [Header("Bool controls")]
    [SerializeField] public bool gameWin = false;
    [SerializeField] public bool gameOver = false;
    [SerializeField] public bool isInteract = false;
    [SerializeField] public bool isPause = false;

    private AudioSource _footSteps;
    private Rigidbody _rb;
    private Camera _mainCamera;
    private Vector3 _velocity;

    RaycastHit hit;
    GameObject map;
    GameObject item;

    private void Awake()
    {
        _footSteps = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        _speedBase = _speed;
        _timeCurrentRunning = _timeRunning;
        run = runMax;
        ActualizarUI(run, runMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            anim = _input.magnitude;
            if (anim > 0f)
            {

                if (!_footSteps.isPlaying && !_isRunning)
                {
                    _footSteps.clip = _walkPlayer;
                    _footSteps.Play();
                }
                else if (_isRunning)
                {
                    if (!_footSteps.isPlaying)
                    {
                        _footSteps.Stop();
                        _footSteps.clip = _runPlayer;
                        _footSteps.Play();
                    }

                }


            }
            else
            {
                _footSteps.clip = null;
            }

            _direction = new Vector3(_input.x, 0.0f, _input.y).normalized;

            ChangePOV();
            ApplyRunning();
            ApplyRotacion();

            RayCastCamera();
            
        }

        PickUpItems();

    }


    private void FixedUpdate()
    {
        ApplyMovement(_direction);
    }

    private void ChangePOV()
    {
        if (_FisrtToThird)
        {
            transform.rotation = Quaternion.Euler(0f, _camFPS.rotation.eulerAngles.y, 0f);
        }
    }

    private void ApplyRunning()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("Run")) && _canRun)
        {
            _speed = _speedExtra;
            _isRunning = true;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetButtonUp("Run"))
        {
            _speed = _speedBase;
            _isRunning = false;
        }

        if (Mathf.Abs(anim) >= 0.1f && _isRunning)
        {
            if (_timeCurrentRunning > 0)
            {
                _timeCurrentRunning -= Time.deltaTime;
                ActualizarUI(_timeCurrentRunning, runMax);
            }
            else
            {
                _speed = _speedBase;
                _isRunning = false;
                _canRun = false;
                _timeNextRunning = Time.time + _timeBetweenRun;
            }
        }

        if (!_isRunning && _timeCurrentRunning <= _timeRunning && Time.time >= _timeNextRunning)
        {
            _timeCurrentRunning += Time.deltaTime;
            ActualizarUI(_timeCurrentRunning, runMax);
            if (_timeCurrentRunning >= _timeRunning)
            {
                _canRun = true;
            }
        }
    }

    private void ActualizarUI(float run, float runMax)
    {
        runStatus.fillAmount = Mathf.Lerp(runStatus.fillAmount, run / runMax, 10f * Time.deltaTime);
    }


    private void ApplyMovement(Vector3 dirPlayer)  //28 speed
    {
        _velocity = dirPlayer * _speed;
        _velocity.y = _rb.velocity.y;
        _rb.velocity = _velocity;
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


    public void RayCastCamera()
    {
        Debug.DrawRay(_camera.position, _camera.forward * _rayDistance, Color.red);

        if (Physics.Raycast(_camera.position, _camera.forward, out hit, _rayDistance, _layerInterac))
        {
            _interact.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Interact")) // Map. Item. StartGame. EndGame.
            {
                if (hit.transform.CompareTag("StartGame"))
                {
                    Debug.Log(hit.transform.name);
                    hit.transform.GetComponent<Interact>().Interactable();
                }

                if (hit.transform.CompareTag("Map"))
                {
                    Debug.Log(hit.transform.name);
                    map = hit.transform.gameObject;
                    hit.transform.GetComponent<Interact>().Interactable();
                }

                if (hit.transform.CompareTag("Item"))
                {
                    Debug.Log(hit.transform.name);
                    item = hit.transform.gameObject;
                    hit.transform.GetComponent<Interact>().Interactable();
                }

                if (hit.transform.CompareTag("EndGame"))
                {
                    Debug.Log(hit.transform.name);
                    hit.transform.GetComponent<Interact>().Interactable();
                }

            }
        }
        else
        {
            _interact.SetActive(false);
        }
    }

    private void PickUpItems()
    {

        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("PickUp"))
        {
            if (canPickUpMap)
            {
                Debug.Log("Agarro mapa");
                map.GetComponent<PickUp>().PickUpItem();
                canPickUpMap = false;
                isInteract = false;
            }

            if (canPickUpItem)
            {
                Debug.Log("Agarro item");
                item.GetComponent<PickUp>().PickUpItem();
                canPickUpItem = false;
                isInteract = false;
            }

        }
    }

}
