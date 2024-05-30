using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Texture m_MainTexture1;
    [SerializeField] private Texture m_MainTexture2;
    [SerializeField] private Countdown _count;
    Renderer m_Renderer;

    [Header("Vida Madre")]
    [SerializeField] private float vida;
    [SerializeField] private float vidaMax;
    [SerializeField] private Image playerVida;

    [Header("Animacion - Control final 1")]
    [SerializeField] private PlayableDirector _sceneDied;
    [SerializeField] private GameObject _cameraThird;
    [SerializeField] private GameObject _cameraWin;
    [SerializeField] private float _timeDied = 9.5f;
    [SerializeField] private ConversationInteract _inicio;
    [SerializeField] private GameObject _player;
    [SerializeField] private MomAnimations _anims;
    [SerializeField] private GameObject _buttonRestart;
    [SerializeField] private GameObject _barraVida;
    [SerializeField] private GameObject _miniMap;
    [SerializeField] private GameObject _bigMap;
    [SerializeField] private GameObject _itemUI;
    [SerializeField] private ChangeMinimap _changeMap;
    [SerializeField] private GameObject _itemCamara;
    [SerializeField] private GameObject _mapaCamara;
    [SerializeField] private GameObject _itemIndicacion;
    [SerializeField] private GameObject _mapaIndicacion;
    [SerializeField] private GameObject _itemGrupo;
    [SerializeField] private GameObject _mapaGrupo;

    [Header("Music")]
    [SerializeField] private GameObject _music1;
    [SerializeField] private GameObject _music2;

    private bool _end;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        vida = vidaMax;
        ActualizarUI(vida, vidaMax);
    }

    // Update is called once per frame
    void Update()
    {


        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    m_Renderer.material.SetTexture("_MainTex", m_MainTexture1);
        //}

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    m_Renderer.material.SetTexture("_MainTex", m_MainTexture2);
        //}

        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    m_Renderer.material.SetTexture("_MainTex", m_MainTexture3);
        //}

        bool activo = _player.activeSelf;

        if (_inicio._start && Time.timeScale != 0f && activo)
        {
            if (_end)
            {
                return;
            }
            RecivirDanio(0.01f);

        }
    }

    private void RecivirDanio(float cantidad)
    {
        vida -= cantidad;
        ActualizarUI(vida, vidaMax);
        if (vida <= 0)
        {
            StartCoroutine(LostGame());
            _sceneDied.Play();
            _cameraThird.SetActive(false);
            _cameraWin.SetActive(false);
            _end = true;
        }

    }

    public void RestaurarSalud(float cantidad)
    {
        vida += cantidad;
        if (vida > vidaMax)
        {
            vida = vidaMax;
        }

        ActualizarUI(vida, vidaMax);
    }

    private void ActualizarUI(float vida, float vidaMax)
    {
        playerVida.fillAmount = Mathf.Lerp(playerVida.fillAmount, vida / vidaMax, 10f * Time.deltaTime);
    }

    IEnumerator LostGame()
    {
        _music1.SetActive(false);
        _music2.SetActive(true);
        _player.GetComponent<AudioSource>().enabled = false;
        _changeMap.enabled = false;
        _player.SetActive(false);
        _anims.CancelarAnimacion();
        _barraVida.SetActive(false);
        _miniMap.SetActive(false);
        _bigMap.SetActive(false);
        _itemUI.SetActive(false);
        _itemCamara.SetActive(false);
        _mapaCamara.SetActive(false);
        _itemIndicacion.SetActive(false);
        _mapaIndicacion.SetActive(false);
        _itemGrupo.SetActive(false);
        _mapaGrupo.SetActive(false);
        yield return new WaitForSeconds(_timeDied);

        m_Renderer.material.SetTexture("_MainTex", m_MainTexture2);
        _buttonRestart.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
