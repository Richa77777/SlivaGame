using System;
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

        private Action<bool, int> _cellOnOff;
        private Action<bool, int> _cellCountOnOff;
        private Action<bool, int, Sprite> _cellImageOnOff;
        private Action<int, int> _cellSetCount;
        private Action<Sprite, int> _cellSetImage;

        private void Start()
        {
            _inventory = FindObjectOfType<Player.PlayerInventoryScript>(true).PlayerInventory;

            for (int i = 0; i <= _slots.Length - 1; i++)
            {
                _slotsImages[i] = _slots[i].transform.GetChild(0).GetComponent<Image>();
                _slotsItemCount[i] = _slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            }

            _cellOnOff += OnOffCell;
            _cellCountOnOff += OnOffCellCount;
            _cellImageOnOff += OnOffCellImage;
            _cellSetCount += SetCellCount;
            _cellSetImage += SetCellImage;
        }

        private void OnEnable()
        {
            _cellOnOff += OnOffCell;
            _cellCountOnOff += OnOffCellCount;
            _cellImageOnOff += OnOffCellImage;
            _cellSetCount += SetCellCount;
            _cellSetImage += SetCellImage;
        }

        private void OnDisable()
        {
            _cellOnOff -= OnOffCell;
            _cellCountOnOff -= OnOffCellCount;
            _cellImageOnOff -= OnOffCellImage;
            _cellSetCount -= SetCellCount;
            _cellSetImage -= SetCellImage;
        }

        public void OnOffCell(bool isOn, int cellNumber)
        {
            _slots[cellNumber].gameObject.SetActive(isOn);
        }

        public void OnOffCellCount(bool isOn, int cellNumber)
        {
            _slotsItemCount[cellNumber].gameObject.SetActive(isOn);
        }

        public void SetCellCount(int value, int cellNumber)
        {
            _slotsItemCount[cellNumber].text = value.ToString("n0");
        }

        public void OnOffCellImage(bool isOn, int cellNumber, Sprite sprite)
        {
            _slotsImages[cellNumber].sprite = isOn == true ? sprite : null;
            _slotsImages[cellNumber].gameObject.SetActive(isOn);
        }

        public void SetCellImage(Sprite sprite, int cellNumber)
        {
            _slotsImages[cellNumber].sprite = sprite;
            _slotsImages[cellNumber].preserveAspect = true;
        }

        public void Enable()
        {
            for (int i = 0; i < _inventory.Container.Items.Count; i++)
            {
                _cellOnOff(_inventory.Container.Items[i].ItemsCount > 0 ? true : false, i);
                _cellSetCount(_inventory.Container.Items[i].ItemsCount, i);
                _cellSetImage(_inventory.Container.Items[i].Item.ItemSprite, i);
                _cellCountOnOff(_inventory.Container.Items[i].ItemsCount > 1 ? true : false, i);
                _cellImageOnOff(_inventory.Container.Items[i].Item.ItemSprite != null ? true : false, i, _inventory.Container.Items[i].Item.ItemSprite);
            }

            for (int i = _inventory.Container.Items.Count; i < _inventory.InventoryLimit - _inventory.Container.Items.Count; i++)
            {
                _cellOnOff(false, i);
            }
        }
    }
}
