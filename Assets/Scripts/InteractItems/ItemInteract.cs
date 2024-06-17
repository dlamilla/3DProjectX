using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : Interact
{
    [SerializeField] private GameObject _item;
    [SerializeField] private GameObject _indicationTeclaE;
    [SerializeField] private GameObject _cameraFirstPerson;
    [SerializeField] private GameObject _camera2; //10
    [SerializeField] private GameObject _objScena;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _indicationTeclaF;
    [SerializeField] private GameObject _miniMap;
    [SerializeField] private GameObject _inventoryUI;
    [SerializeField] private GameObject _barraVida;
    [SerializeField] private GameObject _barraCorrer;
    public override void Interactable()
    {
        base.Interactable();
        ItemVisual();
    }

    private void ItemVisual()
    {
        _cameraFirstPerson.SetActive(false);
        _inventoryUI.SetActive(false);
        _camera2.SetActive(true);
        _miniMap.SetActive(false);
        _item.SetActive(true);
        _indicationTeclaE.SetActive(true);
        _objScena.SetActive(false);
        _player.GetComponent<Player>().canMove = false;
        _player.GetComponent<Player>().canPickUpItem = true;
        _player.GetComponent<Player>().isInteract = true;
        _player.GetComponent<Collider>().enabled = false;
        _indicationTeclaF.SetActive(false);
        _barraVida.SetActive(false);    
        _barraCorrer.SetActive(false); 
        this.gameObject.GetComponent<Collider>().enabled = false;
    }
}
