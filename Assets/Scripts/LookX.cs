using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField] private float _sensivity = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += mouseX * _sensivity;
        transform.localEulerAngles = newRotation;
    }
}
