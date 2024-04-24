using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRuleta : MonoBehaviour
{
    [Header("Coleccionables")]
    [SerializeField] private GameObject _item1;
    [SerializeField] private GameObject _item2;
    [SerializeField] private GameObject _item3;
    [SerializeField] private GameObject _item4;
    [SerializeField] private GameObject _item5;
    [SerializeField] private GameObject _item6;
    [SerializeField] private GameObject _item7;
    [SerializeField] private GameObject _item8;

    [Header("Collision")]
    [SerializeField] private GameObject _item1x;
    [SerializeField] private GameObject _item2x;
    [SerializeField] private GameObject _item3x;
    [SerializeField] private GameObject _item4x;
    [SerializeField] private GameObject _item5x;
    [SerializeField] private GameObject _item6x;
    [SerializeField] private GameObject _item7x;
    [SerializeField] private GameObject _item8x;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_item1.activeSelf)
        {
            _item1x.SetActive(false);
            //Destroy(_item1x);
        }

        if (_item2.activeSelf)
        {
            //Destroy(_item2x);
            _item2x.SetActive(false);
        }

        if (_item3.activeSelf)
        {
            _item3x.SetActive(false);
            // Destroy(_item3x);
        }

        if (_item4.activeSelf)
        {
            _item4x.SetActive(false);
            //Destroy(_item4x);
        }

        if (_item5.activeSelf)
        {
            _item5x.SetActive(false);
            //Destroy(_item5x);
        }

        if (_item6.activeSelf)
        {
            _item6x.SetActive(false);
            //Destroy(_item6x);
        }

        if (_item7.activeSelf)
        {
            _item7x.SetActive(false);
            //Destroy(_item7x);
        }

        if (_item8.activeSelf)
        {
            _item8x.SetActive(false);
            //Destroy(_item8x);
        }
    }
}
