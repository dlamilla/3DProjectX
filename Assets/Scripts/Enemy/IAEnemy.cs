using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using XInputDotNetPure;

public enum AlertStage
{
    Peaceful,
    Intrigued,
    Alerted
}
public class IAEnemy : MonoBehaviour
{
    [Header("FOV Enemy")]
    [SerializeField] public float fov;
    [Range(0, 360)] public float fovAngle;
    [SerializeField] public AlertStage alertStage;
    [Range(0, 50)] public float alertLevel;
    [SerializeField] private LayerMask _player;

    [Header("Waypoints Patrol")]
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private Transform _playerFollow;
    private int _index = 0;


    private NavMeshAgent _nav;
    private AudioSource _audio;
    PlayerIndex playerIndex;
    private void Awake()
    {
        _nav = GetComponent<NavMeshAgent>();
        _audio = GetComponent<AudioSource>();
        GamePad.SetVibration(playerIndex, 0f, 0f);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool playerInFOV = false;
        Collider[] targetsInFOV = Physics.OverlapSphere(transform.position, fov, _player);
        foreach (Collider c in targetsInFOV)
        {
            if (c.CompareTag("Player") && c.gameObject.GetComponent<Player>().enabled)
            {
                float signedAngle = Vector3.Angle(transform.forward, c.transform.position - transform.position);
                if (Mathf.Abs(signedAngle) < fovAngle / 2)
                {
                    playerInFOV = true;
                }

                break;
            }
        }

        UpdateAlertState(playerInFOV);
    }
    private void UpdateAlertState(bool playerInFOV)
    {
        switch (alertStage)
        {
            case AlertStage.Peaceful:
                Patrol();
                _audio.Stop();
                
                if (playerInFOV)
                {
                    alertStage = AlertStage.Intrigued;
                }
                break;
            case AlertStage.Intrigued:
                GamePad.SetVibration(playerIndex, 0f, 0f);
                if (playerInFOV)
                {
                    _audio.Play();
                    alertLevel++;
                    if (alertLevel >= 50)
                    {
                        alertStage = AlertStage.Alerted;
                    }
                }
                else
                {
                    alertLevel--;
                    if (alertLevel <= 0)
                    {
                        alertStage = AlertStage.Peaceful;
                    }
                }
                break;
            case AlertStage.Alerted:
                _nav.SetDestination(_playerFollow.position);
                
                GamePad.SetVibration(playerIndex, 1f, 1f);
                if (!playerInFOV)
                {
                    alertStage = AlertStage.Intrigued;
                }
                break;
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

}
