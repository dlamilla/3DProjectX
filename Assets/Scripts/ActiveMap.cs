using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ActiveMap : MonoBehaviour
{
    [SerializeField] private GameObject _mapItem;
    [SerializeField] private GameObject _indication;
    [SerializeField] private GameObject _cameraThirdPerson; //20
    [SerializeField] private GameObject _cameraFirstPerson;
    [SerializeField] private GameObject _camera2; //10
    [SerializeField] private GameObject _objScena;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _indication1;
    [SerializeField] private GameObject _miniMap;
    [SerializeField] private GameObject _itemBackground;

    [SerializeField] private bool _active;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool _ThirdOrFirst = _player.GetComponent<Player>()._FisrtToThird;

        if (Input.GetKeyDown(KeyCode.F) && _active)
        {
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            _cameraThirdPerson.SetActive(false);
            _cameraFirstPerson.SetActive(false);
            _camera2.SetActive(true);
            _mapItem.SetActive(true);
            _indication.SetActive(true);
            _objScena.SetActive(false);
            _player.SetActive(false);
            _indication1.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && _active)
        {
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = true;
            if (_ThirdOrFirst)
            {
                _cameraFirstPerson.SetActive(true);
            }
            else
            {
                _cameraThirdPerson.SetActive(true);
            }
            
            _camera2.SetActive(false);
            _mapItem.SetActive(false);
            _indication.SetActive(false);
            _objScena.SetActive(false);
            _player.SetActive(true);
            _itemBackground.SetActive(true);
            _player.GetComponent<Player>()._map = true;
            this.gameObject.SetActive(false);
            _miniMap.SetActive(true);
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
