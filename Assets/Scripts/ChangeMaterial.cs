using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] private Texture m_MainTexture1;
    [SerializeField] private Texture m_MainTexture2;
    [SerializeField] private Countdown _count;
    Renderer m_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int tiempo = (int)_count.tiempoInicio;
        if (tiempo <= 0)
        {
            m_Renderer.material.SetTexture("_MainTex", m_MainTexture2);
        }
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
    }

    
}
