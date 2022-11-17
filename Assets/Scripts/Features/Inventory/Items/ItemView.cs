using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Features.Inventory.Items
{
    internal interface IItemView
    {
        void Init(IItem item, UnityAction clickAction);
        void Select();
        void Unselect();
    }

    internal class ItemView : MonoBehaviour
    {
        [SerializeField] private Image _icon;

        [SerializeField] private TMP_Text _text;

        [SerializeField] private Button _button;

        [SerializeField] private GameObject _selectedBackground;

        [SerializeField] private GameObject _unselectedBackground;

        private void OnDestroy() => Deinit();

        public void Init(IItem item, UnityAction clickAction)
        {
            _text.text = item.Info.Title;
            _icon.sprite = item.Info.Icon;
            _button.onClick.AddListener(clickAction);
        }

        public void Deinit()
        {
            _text.text = string.Empty; 
            _icon.sprite = null;
            _button.onClick.RemoveAllListeners();
        }

        public void Select() => SetSelected(true);


        public void Unselect() => SetSelected(false);
        

        private void SetSelected(bool isSelected)
        {
            _selectedBackground.SetActive(isSelected);
            _unselectedBackground.SetActive(!isSelected);
        }

    }
}