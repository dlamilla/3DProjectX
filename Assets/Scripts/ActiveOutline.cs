using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOutline : MonoBehaviour
{
    public Material _mesh;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _mesh.SetFloat("_Scale", 1.05f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _mesh.SetFloat("_Scale", 0f);
        }
    }
}
