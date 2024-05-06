using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cheats : MonoBehaviour
{
    [SerializeField] private List<string> cheats;
    [SerializeField] private ChangeMaterial _restaurar;
    [SerializeField] private float _health;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _cheats;
    [SerializeField] private TextMeshProUGUI _text;

    private int cont = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            cont++;
            if (cont == 1)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                _player.enabled = false;              
                _cheats.SetActive(true);
                
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                _player.enabled = true;
                _cheats.SetActive(false);
                cont = 0;
            }
                
        }
    }

    public void SetInputText(string inputText)
    {
        Debug.Log(inputText);
        for (int i = 0; i < cheats.Count; i++)
        {
            if (cheats[i] == inputText.ToUpper())
            {
                _restaurar.RestaurarSalud(_health);
            }

        }
        
    }
}
