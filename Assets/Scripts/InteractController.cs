using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractController : MonoBehaviour
{
    [SerializeField] private GameObject _indication;
    [SerializeField] private Collection _collet;
    [SerializeField] private GameObject _textIndicacion;
    [SerializeField] private TextMeshProUGUI _textTMP;

    private bool _active;
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

                if (_collet._itemsCatch == 8)
                {
                    _textTMP.text = "Return to the initial camp!!";
                    StartCoroutine(Indicaciones());
                }

                
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

    private IEnumerator Indicaciones()
    {
        _textIndicacion.SetActive(true);
        yield return new WaitForSeconds(2f);
        _textIndicacion.SetActive(false);
    }
}
