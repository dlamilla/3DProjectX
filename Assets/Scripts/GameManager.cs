using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject btn1;
    [SerializeField] private GameObject btn2;
    [SerializeField] private GameObject btn3;
    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject text;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Collection _collect;

    [SerializeField] private GameObject _miniMap;
    [SerializeField] private GameObject _bigMap;

    [SerializeField] private GameObject _winObject;


    public int cont = 0;
    private bool _active = true;
    // Start is called before the first frame update
    void Start()
    {
        //Hide curser
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       // if (_player.activeSelf)
       // {
            if (btn1.activeSelf == false)
            {
                cont = 0;
            }

            //Activate mouse
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                btn1.SetActive(true);
                btn2.SetActive(true);
                btn3.SetActive(true);
                _player.GetComponent<Player>().enabled = false;
                _bigMap.SetActive(false);
                Time.timeScale = 0f;
                //if (cont == 0)
                //{

                //    cont++;

                //}
                //else
                //{
                //    cont = 0;
                //    Time.timeScale = 1f;
                //    //Hide curser
                //    Cursor.visible = false;
                //    Cursor.lockState = CursorLockMode.Locked;
                //    ActiveButtons();
                //    _miniMap.SetActive(true);
                //    _player.GetComponent<Player>().enabled = true;
                //}
            }

            if (_collect._itemsCatch == 8 || _collect._itemsCatchBckp == 8)
            {
                if (_active)
                {
                    StartCoroutine(Final());
                }
                

            }
       // }
        
    }

    public void ActiveButtons()
    {
        btn1.SetActive(!btn1.activeSelf);
        btn2.SetActive(!btn2.activeSelf);
        btn3.SetActive(!btn3.activeSelf);
    }

    private IEnumerator Final()
    {
        _text.text = "Go back with your Mommy!!";
        text.SetActive(true);
        _winObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
        _active = false;
    }

    public void ActiveMinimap()
    {
        bool mapActive = _player.GetComponent<Player>()._map;
        if (mapActive)
        {
            _miniMap.SetActive(true);
        }
    }
}
