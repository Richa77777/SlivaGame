using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Inventory;

public class DisplayInventory : MonoBehaviour
{
    private InventoryObject _inventory;

    [SerializeField] private GameObject[] _slots = new GameObject[9];

    private Image[] _slotsImages = new Image[9];
    private TextMeshProUGUI[] _slotsItemCount = new TextMeshProUGUI[9];

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryScript>().PlayerInventory;

        for (int i = 0; i <= _slots.Length - 1; i++)
        {
            _slotsImages[i] = _slots[i].transform.GetChild(0).GetComponent<Image>();
            _slotsItemCount[i] = _slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        }

        UpdateInventory();
    }

    private void Update()
    {
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        for (int i = 0; i <= _inventory.Container.Count - 1; i++)
        {
            _slots[i].SetActive(true);
            _slotsImages[i].sprite = _inventory.Container[i].ItemSprite;
            _slotsItemCount[i].text = _inventory.Container[i].Count.ToString("n0");

            if (_inventory.Container[i].Count == 0)
            {
                _slots[i].SetActive(false);
            }
        }
    }
}
