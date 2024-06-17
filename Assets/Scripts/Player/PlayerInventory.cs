using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] public List<ItemSO> inventory;
    [SerializeField] public GameObject prefabItem;
    [SerializeField] public Transform contenedor;
    [SerializeField] private GameObject inventoryUI;
    Player _player;
    private void Awake()
    {
        inventory = new List<ItemSO>();
        _player = GetComponent<Player>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_player.isPause)
        {
            return;
        }

        if (!_player.isInteract && _player._map)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
            }
        }

    }

    public void SaveItem(ItemSO itemPickUp)
    {
        inventory.Add(itemPickUp);
        GameObject uiItem = Instantiate(prefabItem);
        uiItem.transform.SetParent(contenedor);
        uiItem.transform.localPosition = new Vector3(0, 0, 0);
        uiItem.transform.localRotation = Quaternion.Euler(0, 0, 0);
        uiItem.transform.localScale = new Vector3(1, 1, 1);
        uiItem.GetComponent<Image>().sprite = itemPickUp.iconItem;
    }
}
