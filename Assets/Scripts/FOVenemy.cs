using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FOVenemy : MonoBehaviour
{
    [SerializeField] private float fov;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Handles.color = new Color(0, 1, 0, 0.3f);
        Handles.DrawSolidDisc(transform.position, transform.up, fov);
    }
}
