using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject btn1;
    [SerializeField] private GameObject btn2;
    [SerializeField] private GameObject btn3;
    [SerializeField] private GameObject _player;
    public int cont = 0;
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
        if (_player.activeSelf)
        {
            if (btn1.activeSelf == false)
            {
                cont = 0;
            }

            //Activate mouse
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (cont == 0)
                {

                    cont++;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    ActiveButtons();
                    Time.timeScale = 0f;
                }
                else
                {
                    cont = 0;
                    Time.timeScale = 1f;
                    //Hide curser
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    ActiveButtons();

                }
            }
        }
        
    }

    public void ActiveButtons()
    {
        btn1.SetActive(!btn1.activeSelf);
        btn2.SetActive(!btn2.activeSelf);
        btn3.SetActive(!btn3.activeSelf);
    }
}
