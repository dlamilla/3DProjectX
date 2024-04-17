using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveShader : MonoBehaviour
{
    [SerializeField] private GameObject _item;
    [SerializeField] private GameObject _indication;
    [SerializeField] private GameObject _camera1; //20
    [SerializeField] private GameObject _camera2; //10
    [SerializeField] private GameObject _objScena;
    [SerializeField] private GameObject _player;
    [SerializeField] private Item _itemX;
    [SerializeField] private GameObject _activeRolutte;

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
            _item.SetActive(true);
            _indication.SetActive(true);
            _objScena.SetActive(false);
            _player.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && _active)
        {

            StartCoroutine(StartShader());
            

            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _active = true;
            Debug.Log("Entro");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _active = false;
        }
    }

    private IEnumerator StartShader()
    {
        _itemX.ItemCollect();
        yield return new WaitForSeconds(2f);
        _camera1.SetActive(true);
        _camera2.SetActive(false);
        _item.SetActive(false);
        _indication.SetActive(false);
        _activeRolutte.SetActive(true);
        _player.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

}
