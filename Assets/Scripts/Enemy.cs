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
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private int _index = 0;
    [SerializeField] private Collider[] _collidersObj;
    private NavMeshAgent _nav;
    private AudioSource _audio;

    private void Awake()
    {
        _nav = GetComponent<NavMeshAgent>();
        _audio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Vector3.Distance(transform.position, _player.transform.position) <= _radius)
        {
            FollowPlayer();
        }
        else
        {

            Patrol();
        }


    }

    private void FollowPlayer()
    {
        _collidersObj = Physics.OverlapSphere(transform.position, _radius, _layerMask);

        if (_collidersObj.Length > 0)
        {
            _nav.SetDestination(_player.position);
        }
    }

    private void Patrol()
    {
        if (_waypoints.Count == 0)
        {
            return;
        }

        if (Vector3.Distance(_waypoints[_index].position, transform.position) <= 3f)
        {
            _index = (_index + 1) % _waypoints.Count;
        }

        _nav.SetDestination(_waypoints[_index].position);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _audio.Play();

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<Player>().MoveToStart();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}

