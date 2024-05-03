using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomAnimations : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Countdown _count;
    private Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EmpezarAnimaciones", 3f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void EmpezarAnimaciones()
    {
        StartCoroutine(Animaciones());
    }

    IEnumerator Animaciones()
    {
        yield return new WaitForSeconds(_time);
        _anim.SetTrigger("inicio");
    }

    public void CancelarAnimacion()
    {
        CancelInvoke("EmpezarAnimaciones");
    }
}
