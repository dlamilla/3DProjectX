using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using XInputDotNetPure;

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
    PlayerIndex playerIndex;
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
        bool canFollow = _player.transform.GetComponent<Player>().canMove;

        if (canFollow)
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
            if (other.gameObject.GetComponent<Player>().canMove)
            {
                _audio.Play();
                GamePad.SetVibration(playerIndex, 1f, 1f);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _audio.Stop();
            GamePad.SetVibration(playerIndex, 0f, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<Player>().MoveToStart();
            GamePad.SetVibration(playerIndex, 0f, 0f);
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }
}

