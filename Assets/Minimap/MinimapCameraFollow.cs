using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraFollow : MonoBehaviour
{
    [SerializeField] private MinimapSettings _settings;
    [SerializeField] private float _cameraHeight = 100f;

    private void Awake()
    {
        _settings = GetComponentInParent<MinimapSettings>();
        //_cameraHeight = transform.position.y;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = _settings._targetToFollow.transform.position;

        transform.position = new Vector3(targetPosition.x, targetPosition.y + _cameraHeight, targetPosition.z);

        if (_settings.rotateWithTheTarget)
        {
            Quaternion targetRotation = _settings._targetToFollow.transform.rotation;

            transform.rotation = Quaternion.Euler(90, targetRotation.eulerAngles.y, 0);
        }
    }
}
