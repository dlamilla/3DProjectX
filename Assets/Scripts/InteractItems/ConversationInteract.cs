using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ConversationInteract : Interact
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _position;
    [SerializeField] private GameObject _indication1;
    [SerializeField] private GameObject _indication2;
    [SerializeField] private GameObject _map;
    [SerializeField] private GameObject _activeMap;
    [SerializeField] private float _time;
    [SerializeField] private GameObject _limit;
    [SerializeField] private GameObject _barraVida;
    [SerializeField] private GameObject _barraCorrer;

    [Header("Animacion Inicio")]
    [SerializeField] private PlayableDirector _scene;
    [SerializeField] private Collider _sphere;
    
    public bool _start = false;
    public override void Interactable()
    {
        base.Interactable();
        StartCoroutine(Conversation());
    }

    private IEnumerator Conversation()
    {
        _barraCorrer.SetActive(false);
        _indication1.SetActive(true);
        _barraVida.SetActive(true);
        _scene.Play();
        yield return new WaitForSeconds(_time);  //9f
        _indication1.SetActive(false);
        _indication2.SetActive(true);
        yield return new WaitForSeconds(3f);
        _barraCorrer.SetActive(true);
        _indication2.SetActive(false);
        _map.SetActive(true);
        _activeMap.SetActive(true);
        _limit.SetActive(false);
        _player.GetComponent<Transform>().position = _position.position;
        _player.GetComponent<Transform>().rotation = _position.rotation;
        _start = true;
    }  
}
