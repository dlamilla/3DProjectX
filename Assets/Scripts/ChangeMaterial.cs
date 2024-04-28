using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Texture m_MainTexture1, m_MainTexture2, m_MainTexture3;
    Renderer m_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
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
    }

    
}
