using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMinimap : MonoBehaviour
{
    [SerializeField] private GameObject _miniMap;
    [SerializeField] private GameObject _bigMap;
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
        
        if (_player.isPause)
        {
            return;
        }

        if (_isMap)
        {
            if (Input.GetKeyDown(KeyCode.Tab) || Input.GetButtonDown("Open"))
            {

                if (_miniMap.activeSelf)
                {
                    _miniMap.SetActive(false);
                    _bigMap.SetActive(true);
                }else
                {
                    _miniMap.SetActive(true);
                    _bigMap.SetActive(false);
                }

            }

            if (_input != 0f)
            {
                _miniMap.SetActive(true);
                _bigMap.SetActive(false);
            }
        }
              
    }
}
