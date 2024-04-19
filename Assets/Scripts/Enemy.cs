using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform[] _waypoints;

    [SerializeField] private int _index;
    [SerializeField] private Collider[] _collidersObj;
    private NavMeshAgent _nav;
    private Vector3 _position;

    private void Awake()
    {
        _nav = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        IterateWaypointIndex();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {


        _collidersObj = Physics.OverlapSphere(transform.position, _radius, _layerMask);

        //foreach (Collider item in objetos_detectados)
        //{
        //    if (item.tag == "Player")
        //    {
        //        GetComponent<NavMeshAgent>().SetDestination(objectivo.position);
        //    }
        //}

        if (_collidersObj.Length > 0)
        {
            _nav.SetDestination(_player.position);
        }
        else
        {
            if (Vector3.Distance(transform.position,_position) < 1f)
            {
                IterateWaypointIndex();
                UpdateDestination();

            }
            
        }
    }

    private void UpdateDestination()
    {
        _position = _waypoints[_index].position;
        _nav.SetDestination(_position);
    }

    private void IterateWaypointIndex()
    {
        _index++;
        Debug.Log(_index);
        if (_index >= _waypoints.Length)
        {
            _index = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
