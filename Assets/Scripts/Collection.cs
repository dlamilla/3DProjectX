using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collection : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] public float _itemsCatch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _itemsCatch.ToString("0");
    }

    

    public void ItemSum(float item)
    {
        _itemsCatch += item;
    }

}
