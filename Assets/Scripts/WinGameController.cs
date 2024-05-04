using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WinGameController : MonoBehaviour
{
    [Header("Desactivar objetos")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _mom;
    [SerializeField] private GameObject _son1;
    [SerializeField] private GameObject _son2;
    [SerializeField] private GameObject _son3;
    [SerializeField] private GameObject _family;
    [SerializeField] private GameObject _barraVida;

    [Header("Textos")]
    [SerializeField] private GameObject _indication;
    [SerializeField] private GameObject _thankTMP;
    [SerializeField] private GameObject _credits;
    [SerializeField] private GameObject _button;

    [Header("Camaras")]
    [SerializeField] private GameObject _thirdCamera;
    [SerializeField] private GameObject _cameraObject;
    [SerializeField] private GameObject _cameraItem;
    [SerializeField] private GameObject _miniMap;
    [SerializeField] private GameObject _bigMap;
    [SerializeField] private GameObject _cameraA;
    [SerializeField] private GameObject _cameraB;
    [SerializeField] private GameObject _cameraDied;

    [Header("Animacion Fin")]
    [SerializeField] private PlayableDirector _scene;  //4f

    [Header("Audio")]
    [SerializeField] private GameObject _audio;
    [SerializeField] private GameObject _audioWin;

    private bool _active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(WinGame());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _indication.SetActive(true);
            _active = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _indication.SetActive(false);
            _active = false;
        }
    }

    IEnumerator WinGame()
    {
        _scene.Play();

        //Family
        _player.SetActive(false);
        _mom.SetActive(false);
        _son1.SetActive(false);
        _son2.SetActive(false);
        _son3.SetActive(false);
        _family.SetActive(true);

        //Audio
        _audio.SetActive(false);
        _audioWin.SetActive(true);

        //Cameras
        _thirdCamera.SetActive(false);
        _cameraA.SetActive(false);
        _cameraB.SetActive(false);
        _cameraDied.SetActive(false);

        //CameraItem
        _cameraObject.SetActive(false);
        _cameraItem.SetActive(false);

        //Maps
        _miniMap.SetActive(false);
        _bigMap.SetActive(false);

        //Indication
        _indication.SetActive(false);

        //Barra vida
        _barraVida.SetActive(false);

        _thankTMP.SetActive(true);
        yield return new WaitForSeconds(2f);
        _thankTMP.SetActive(false);
        _credits.SetActive(true);
        yield return new WaitForSeconds(2f);
        _credits.SetActive(false);
        _button.SetActive(true);
    }
}
