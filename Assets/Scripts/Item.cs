using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    //[SerializeField] private GameObject _effect;
    [SerializeField] private float _cont;
    [SerializeField] private Collection _collection;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void ItemCollect()
    {
        _collection.ItemSum(_cont);

        this.gameObject.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("aaaaa");
                _collection.ItemSum(_cont);
                this.gameObject.SetActive(false);
            }

        }
    }
}
