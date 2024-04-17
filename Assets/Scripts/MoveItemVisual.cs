using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItemVisual : MonoBehaviour
{
    [SerializeField] private float _speedH;
    [SerializeField] private float _speedV;

    float moveH;
    float moveV;

    private void OnMouseDrag()
    {
        moveH -= _speedH * Input.GetAxis("Mouse X");
        moveV += _speedV * Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles = new Vector3(moveV, moveH, 0f);
        }
    }
}
