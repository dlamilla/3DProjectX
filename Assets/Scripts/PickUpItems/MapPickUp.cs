using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPickUp : PickUp
{
    [SerializeField] private GameObject _mapItem;
    [SerializeField] private GameObject _indication;
    [SerializeField] private GameObject _cameraFirstPerson;
    [SerializeField] private GameObject _camera2; //10
    [SerializeField] private GameObject _objScena;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _miniMap;
    [SerializeField] private GameObject _barraVida;
    [SerializeField] private GameObject _barraCorrer;

    [Header("Sonido")]
    [SerializeField] private AudioClip _sound;

    public override void PickUpItem()
    {
        base.PickUpItem();
        PickUpMap();
    }

    private void PickUpMap()
    {
        AudioController.Instance.PlaySound(_sound);
        _cameraFirstPerson.SetActive(true);

        _camera2.SetActive(false);
        _mapItem.SetActive(false);
        _indication.SetActive(false);
        _objScena.SetActive(false);
        _player.GetComponent<Player>().canMove = true;
        _player.GetComponent<Player>()._map = true;
        this.gameObject.SetActive(false);
        _miniMap.SetActive(true);
        _barraVida.SetActive(true);
        _barraCorrer.SetActive(true);
    }
}
