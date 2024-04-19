using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    [SerializeField] private Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float angleRadian = Mathf.Atan2(_player.position.z - transform.position.z, _player.position.x - transform.position.x);
        //float angleGradius = (180 / Mathf.PI) * angleRadian - 0;
        //transform.rotation = Quaternion.Euler(0f, angleGradius, 0f);
        Vector3 _dir = _player.transform.position - transform.position;
        transform.LookAt(_dir);
    }
}
