using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : PickUp
{
    [Header("Control Pick Up")]
    [SerializeField] private ItemSO idItem;
    [SerializeField] private GameObject _item;
    [SerializeField] private GameObject _indicationTeclaE;
    [SerializeField] private GameObject _cameraFirstPerson;
    [SerializeField] private GameObject _camera2; //10
    [SerializeField] private GameObject _player;
    //[SerializeField] private GameObject _activeRolutte;
    [SerializeField] private Item _itemX;
    [SerializeField] private GameObject _miniMap;
    //[SerializeField] private GameObject _itemUI;
    //[SerializeField] private GameObject _interfaceItems;
    [SerializeField] private GameObject _barraVida;
    [SerializeField] private GameObject _barraCorrer;
    [SerializeField] private GameOver _restaurar;
    [SerializeField] private float _health;

    public override void PickUpItem()
    {
        base.PickUpItem();
        StartCoroutine(PickUpItemColor());
    }

    private IEnumerator PickUpItemColor()
    {
        _itemX.ItemCollect();
        yield return new WaitForSeconds(2f);
        _indicationTeclaE.SetActive(false);
        _cameraFirstPerson.SetActive(true);
        //_interfaceItems.SetActive(true);
        _camera2.SetActive(false);
        _miniMap.SetActive(true);
        _item.SetActive(false);
        //_itemUI.SetActive(true);
        //_activeRolutte.SetActive(true);
        _player.GetComponent<Player>().canMove = true;
        _player.GetComponent<Collider>().enabled = true;
        _player.GetComponent<PlayerInventory>().SaveItem(idItem);
        _barraVida.SetActive(true);
        _barraCorrer.SetActive(true);
        _restaurar.RestaurarSalud(_health);
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
        this.gameObject.SetActive(false);
    }
}
