using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace InventorySpace
{
    public class DisplayInventory : MonoBehaviour
    {
        private InventoryObject _inventory;

        [SerializeField] private GameObject[] _slots = new GameObject[9];

        private Image[] _slotsImages = new Image[9];
        private TextMeshProUGUI[] _slotsItemCount = new TextMeshProUGUI[9];



        private void Start()
        {
            _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Player.PlayerInventoryScript>().PlayerInventory;

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
            InventorySlot slot;

            if (_inventory.Container.Items.Count == _inventory.InventoryLimit)
            {
                for (int i = 0; i < _inventory.Container.Items.Count; i++)
                {
                    slot = _inventory.Container.Items[i];

                    _slots[i].gameObject.SetActive(true);
                    _slotsImages[i].sprite = slot.Item.ItemSprite;
                    _slotsItemCount[i].text = slot.Count.ToString("n0");

                    if (slot.Count == 0)
                    {
                        _slotsItemCount[i].gameObject.SetActive(false);
                    }

                    else if (slot.Count >= 0)
                    {
                        _slotsItemCount[i].gameObject.SetActive(true);
                    }

                    if (slot.Item.ItemSprite == null)
                    {
                        _slotsImages[i].gameObject.SetActive(false);
                    }

                    else if (slot.Item.ItemSprite != null)
                    {
                        _slotsImages[i].gameObject.SetActive(true);
                    }
                }
            }

            else if (_inventory.Container.Items.Count < _inventory.InventoryLimit)
            {
                for (int i = 0; i < _inventory.Container.Items.Count; i++)
                {
                    slot = _inventory.Container.Items[i];

                    _slots[i].gameObject.SetActive(true);
                    _slotsImages[i].sprite = slot.Item.ItemSprite;
                    _slotsItemCount[i].text = slot.Count.ToString("n0");

                    if (slot.Count == 0)
                    {
                        _slotsItemCount[i].gameObject.SetActive(false);
                    }

                    else if (slot.Count >= 0)
                    {
                        _slotsItemCount[i].gameObject.SetActive(true);
                    }

                    if (slot.Item.ItemSprite == null)
                    {
                        _slotsImages[i].gameObject.SetActive(false);
                    }

                    else if (slot.Item.ItemSprite != null)
                    {
                        _slotsImages[i].gameObject.SetActive(true);
                    }
                }

                for (int i = _inventory.Container.Items.Count; i < _inventory.InventoryLimit - _inventory.Container.Items.Count; i++)
                {
                    _slots[i].gameObject.SetActive(false);
                }
            }

        }
    }
}
