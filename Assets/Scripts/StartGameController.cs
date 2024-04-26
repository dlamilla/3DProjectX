using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : MonoBehaviour
{
    [SerializeField] private GameObject _interact;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _indication;
    [SerializeField] private GameObject _map;
    [SerializeField] private GameObject _activeMap;
    [SerializeField] private GameObject _rolutte;
    [SerializeField] private float _time;
    [SerializeField] private GameObject _limit;
    private bool _start;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _start)
        {
            StartCoroutine(Conversation());

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _interact.SetActive(true);
            _start = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _interact.SetActive(false);
            _start = false;
        }
    }

    private IEnumerator Conversation()
    {
        _player.enabled = false;
        _indication.SetActive(true);
        _interact.SetActive(false);
        yield return new WaitForSeconds(_time);
        _player.enabled = true;
        _indication.SetActive(false);
        _map.SetActive(true);
        _activeMap.SetActive(true);
        _rolutte.SetActive(true);
        _limit.SetActive(false);
    }
}
