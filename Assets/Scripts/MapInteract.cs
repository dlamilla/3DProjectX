using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInteract : Interact
{
    [SerializeField] private GameObject _mapItem;
    [SerializeField] private GameObject _indication;
    [SerializeField] private GameObject _cameraFirstPerson;
    [SerializeField] private GameObject _camera2; //10
    [SerializeField] private GameObject _objScena;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _indication1;
    [SerializeField] private GameObject _miniMap;
    [SerializeField] private GameObject _itemBackground;
    [SerializeField] private GameObject _barraVida;

    public override void Interactable()
    {
        base.Interactable();
        ActivateMap();
    }

    private void ActivateMap()
    {
        _cameraFirstPerson.SetActive(false);
        _camera2.SetActive(true);
        _mapItem.SetActive(true);
        _indication.SetActive(true);
        _objScena.SetActive(false);
        _player.GetComponent<Player>().canMove = false;
        //_player.SetActive(false);
        _indication1.SetActive(false);
        _barraVida.SetActive(false);
        canPickUp = true;
    }
}

