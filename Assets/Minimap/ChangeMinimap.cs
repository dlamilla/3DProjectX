using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMinimap : MonoBehaviour
{
    [SerializeField] private GameObject _miniMap;
    [SerializeField] private GameObject _bigMap;
    [SerializeField] private GameObject _interfaceItems;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _input = _player.anim;
        bool _isMap = _player._map;
        if (_isMap)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                /* cont++;
                if (cont == 1)
                {
                    _miniMap.SetActive(false);
                    _bigMap.SetActive(true);
                    //_player.enabled = false;
                    _interfaceItems.SetActive(false);
                }
                else
                {
                    _miniMap.SetActive(true);
                    _interfaceItems.SetActive(true);
                    _bigMap.SetActive(false);
                    //_player.enabled = true;
                    cont = 0;
                }*/

                if (_miniMap.activeSelf)
                {
                    _miniMap.SetActive(false);
                    _bigMap.SetActive(true);
                    //_player.enabled = false;
                    _interfaceItems.SetActive(false);
                }else
                {
                    _miniMap.SetActive(true);
                    _interfaceItems.SetActive(true);
                    _bigMap.SetActive(false);
                }


            }

            if (_input != 0f)
            {
                _miniMap.SetActive(true);
                _interfaceItems.SetActive(true);
                _bigMap.SetActive(false);
                //_player.enabled = true;
            }
        }
        

        
    }
}
