using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InteractController : MonoBehaviour
{
    [SerializeField] private GameObject _indication1;
    [SerializeField] private GameObject _indication2;
    [SerializeField] private Collection _collet;
    [SerializeField] private GameObject _textIndicacion;
    [SerializeField] private TextMeshProUGUI _textTMP;

    private bool _active;
    private bool _active1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _active == true)
        {
            if (this.gameObject.tag == "Ruleta")
            {
                if (_collet._itemsCatch == 0)
                {
                    Debug.Log("Complete the rolutte");
                    _textTMP.text = "Complete the rolutte";
                    StartCoroutine(Indicaciones());
                }

                if (_collet._itemsCatch == 1)
                {
                    Debug.Log("Let's go, find more items");
                    _textTMP.text = "Let's go, find more items";
                    StartCoroutine(Indicaciones());
                }

                if (_collet._itemsCatch > 1 && _collet._itemsCatch < 8)
                {
                    Debug.Log("Don't stay here, find quicly!!");
                    _textTMP.text = "Don't stay here, find quicly!!";
                    StartCoroutine(Indicaciones());
                }

                


            }
        }

        if (Input.GetKeyDown(KeyCode.G) && _active1 == true)
        {
            SceneManager.LoadScene(2);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_collet._itemsCatch != 8)
            {
                _indication1.SetActive(true);
                _indication2.SetActive(false);
                _active = true;
            }
            else
            {
                _indication1.SetActive(false);
                _indication2.SetActive(true);
                _active1 = true;
            }
            
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _indication1.SetActive(false);
            _indication2.SetActive(false);
            _active = false;
        }
    }

    private IEnumerator Indicaciones()
    {
        _textIndicacion.SetActive(true);
        yield return new WaitForSeconds(2f);
        _textIndicacion.SetActive(false);
    }
}
