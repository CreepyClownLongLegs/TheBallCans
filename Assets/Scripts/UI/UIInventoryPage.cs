using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Inventory.UI
{
    public class UIInventoryPage : MonoBehaviour
    {
        [SerializeField]
        private UIInventoryItem itemPrefab;

        [SerializeField]
        private RectTransform contentPanel;
        [SerializeField]
        private UIInventoryDescription itemDescription;

        List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

        public event Action<int> OnDescriptionRequested, OnItemActionRequested;

        public void Awake()
        {
            Hide();
            itemDescription.ResetDescription();
        }

        private void Start()
        {
        }

        private void OnDestroy()
        {
        }

        public void InitializeInventoryUI(int inventorysize)
        {
            for (int i = 0; i < inventorysize; i++)
            {
                UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
                uiItem.transform.SetParent(contentPanel);
                listOfUIItems.Add(uiItem);
                uiItem.OnItemClicked += OnLeftClicked;
                uiItem.OnRightMouseButtonClick += OnRightClicked;
            }
        }

        public void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
        {
            itemDescription.SetDescription(itemImage, name, description);
            DeselectAllItems();
            listOfUIItems[itemIndex].Select();
        }

        internal void ResetAllItems()
        {
            foreach (var item in listOfUIItems)
            {
                item.ResetData();
                item.Deselect();
            }
        }

        public void UpdateData(int itemIndex, Sprite itemImage)
        {
            if (listOfUIItems.Count > itemIndex)
            {
                listOfUIItems[itemIndex].SetData(itemImage);
            }
        }

        private void OnLeftClicked(UIInventoryItem uiInventoryItem)
        {
            int index = listOfUIItems.IndexOf(uiInventoryItem);
            if (index == -1)
                return;
            OnDescriptionRequested?.Invoke(index);
        }

        private void OnRightClicked(UIInventoryItem uiInventoryItem)
        {
            int index = listOfUIItems.IndexOf(uiInventoryItem);
            if (index == -1)
                return;
            OnItemActionRequested?.Invoke(index);
            Debug.Log(uiInventoryItem.name);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            ResetSelection();
        }

        public void ResetSelection()
        {
            itemDescription.ResetDescription();
            DeselectAllItems();
        }

        private void DeselectAllItems()
        {
            foreach (UIInventoryItem item in listOfUIItems)
            {
                item.Deselect();
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
