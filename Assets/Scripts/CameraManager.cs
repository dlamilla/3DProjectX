using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private MouseSensitivity _mouseSensibility;
    [SerializeField] private CameraAngle _cameraAngle;

    private float _distanceToPlayer;
    private Vector2 _input;
    private CameraRotation _cameraRotation;

    private void Awake()
    {
        _distanceToPlayer = Vector3.Distance(transform.position, _target.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _cameraRotation.yaw += _input.x * _mouseSensibility.horizontal * Time.deltaTime;
        _cameraRotation.pitch += _input.y * _mouseSensibility.vertical * Time.deltaTime;
        _cameraRotation.pitch = Mathf.Clamp(_cameraRotation.pitch, _cameraAngle.min, _cameraAngle.max);
    }

    private void LateUpdate()
    {
        transform.eulerAngles = new Vector3(_cameraRotation.pitch, _cameraRotation.yaw, 0.0f);
        transform.position = _target.position - transform.forward * _distanceToPlayer;
    }

    public void Look(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
    }
}

[Serializable]
public struct MouseSensitivity
{
    public float horizontal;
    public float vertical;
}

public struct CameraRotation
{
    public float pitch;
    public float yaw;
}

[Serializable]
public struct CameraAngle
{
    public float min;
    public float max;
}


