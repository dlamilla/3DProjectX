using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [Header("Tiempo de inicio")]
    [SerializeField] public float tiempoInicio;
    [SerializeField] private bool inicioTiempo;

    [Header("Texto Final")]
    [SerializeField] private TextMeshProUGUI contadorTMP;
    //[SerializeField] private GameObject textOleada;

    // Start is called before the first frame update
    void Start()
    {
        inicioTiempo = true;
        //contadorTMP.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        ContadorDeInicio();
    }

    private void ContadorDeInicio()
    {
        if (inicioTiempo)
        {
            if (tiempoInicio > 0)
            {
                tiempoInicio -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(tiempoInicio / 60);
                int seconds = Mathf.FloorToInt(tiempoInicio % 60);
                Debug.Log(tiempoInicio);
                contadorTMP.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                //Ganador
                inicioTiempo = false;


            }
        }
    }
}
