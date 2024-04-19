using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ActiveMap : MonoBehaviour
{
    [SerializeField] private GameObject _mapItem;
    [SerializeField] private GameObject _indication;
    [SerializeField] private GameObject _camera1; //20
    [SerializeField] private GameObject _camera2; //10
    [SerializeField] private GameObject _objScena;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _indication1;

    [SerializeField] private bool _active;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _active)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            _camera1.SetActive(false);
            _camera2.SetActive(true);
            _mapItem.SetActive(true);
            _indication.SetActive(true);
            _objScena.SetActive(false);
            _player.SetActive(false);
            _indication1.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _active)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;

            _camera1.SetActive(true);
            _camera2.SetActive(false);
            _mapItem.SetActive(false);
            _indication.SetActive(false);
            _objScena.SetActive(true);
            _player.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _active = true;
            _indication1.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _active = false;
            _indication1.SetActive(false);
        }
    }
}
