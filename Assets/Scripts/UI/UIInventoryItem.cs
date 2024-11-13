using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class UIInventoryItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image itemImage;
        [SerializeField]
        private Image borderImage;

        public event Action<UIInventoryItem> OnItemClicked, OnRightMouseButtonClick;

        private bool empty = true;

        public void Awake()
        {
            ResetData();
            Deselect();
        }

        public void ResetData()
        {
            this.itemImage.gameObject.SetActive(false);
            empty = true;
        }

        public void Deselect()
        {
            borderImage.enabled = false;
        }

        public void SetData(Sprite sprite)
        {
            this.itemImage.gameObject.SetActive(true);
            this.itemImage.sprite = sprite;
            empty = false;
        }

        public void Select()
        {
            borderImage.enabled = true;
        }


        public void OnPointerClick(PointerEventData pointerData)
        {
            if (pointerData.button == PointerEventData.InputButton.Right)
            {
                OnRightMouseButtonClick?.Invoke(this);
            }
            else
            {
                OnItemClicked?.Invoke(this);
            }
        }
    }
}
