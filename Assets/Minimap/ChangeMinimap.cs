using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMinimap : MonoBehaviour
{
    [SerializeField] private GameObject _miniMap;
    [SerializeField] private GameObject _bigMap;
    [SerializeField] private GameObject _interfaceItems;
    private Player _player;
    private int cont = 0;

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
        if (Input.GetKeyDown(KeyCode.M))
        {
            cont++;
            if (cont == 1)
            {
                _miniMap.SetActive(false);
                _bigMap.SetActive(true);
                _player.enabled = false;
                _interfaceItems.SetActive(false);
            }
            else
            {
                _miniMap.SetActive(true);
                _interfaceItems.SetActive(true);
                _bigMap.SetActive(false);
                _player.enabled = true;
                cont = 0;
            }
            
        }
    }
}
