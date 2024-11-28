using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class InventorySO : ScriptableObject,IDataPersistence
    {
        [SerializeField]
        private List<InventoryItem> inventoryItems;

        [field: SerializeField]
        public int Size { get; private set; } = 10;
        public Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

        public void Initialize()
        {
            inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < Size; i++)
            {
                inventoryItems.Add(InventoryItem.GetEmptyItem());
            }
        }

        public List<InventoryItem> GetInventoryItems(){
            return this.inventoryItems;
        }

        public void AddItem(InventoryItem item)
        {
            AddItem(item.item);
        }

        public void AddItem(ItemSO item)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                {
                    inventoryItems[i] = new InventoryItem
                    {
                        item = item,
                    };
                    return;
                }
            }
        }

        public Dictionary<int, InventoryItem> GetCurrentInventoryState()
        {
            Dictionary<int, InventoryItem> returnValue = new Dictionary<int, InventoryItem>();
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                    continue;
                returnValue[i] = inventoryItems[i];
            }
            return returnValue;
        }

        public InventoryItem GetItemAt(int itemIndex)
        {
            return inventoryItems[itemIndex];
        }

        public void RemoveItem(int itemIndex, int amount)
        {
            if (inventoryItems.Count > itemIndex)
            {
                if (inventoryItems[itemIndex].IsEmpty)
                    return;
                int reminder = inventoryItems[itemIndex].quantity - amount;
                if (reminder <= 0)
                    inventoryItems[itemIndex] = InventoryItem.GetEmptyItem();
                else
                    inventoryItems[itemIndex] = inventoryItems[itemIndex]
                        .ChangeQuantity(reminder);
                
                InformAboutChange();
            }
        }

        private void InformAboutChange()
        {
            OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
        }

        public void LoadGame(GameData data)
        {
            SerializableDictionary<string, bool> itemsCollectedJSON = data.itemsCollected;
            InventoryItem inventoryItem;
            foreach(KeyValuePair<string,bool> item in itemsCollectedJSON){
                Debug.Log("Loading item: " + item.Key);
                inventoryItem = JsonUtility.FromJson<InventoryItem>(item.Key);
                if(inventoryItem.item!=null){
                    inventoryItem.quantity = 1;
                }
                if(!inventoryItems.Contains(inventoryItem)){
                    this.AddItem(inventoryItem);
                }
            }
        }
        

        public void SaveGame(GameData data)
        {
            SerializableDictionary<string, bool> itemsCollected = new SerializableDictionary<string, bool>();
            itemsCollected = data.itemsCollected;
            foreach(InventoryItem item in inventoryItems){
                string serializedData = JsonUtility.ToJson(item);
                if(!data.itemsCollected.ContainsKey(serializedData) && !itemsCollected.ContainsKey(serializedData)){
                itemsCollected.Add(serializedData, true);
                Debug.Log(serializedData);  
                }
            }
            data.itemsCollected = itemsCollected;
        }
    }

    [Serializable]

    public struct InventoryItem
    {
        public int quantity;
        public ItemSO item;
        public List<ItemParameter> itemState;
        public bool IsEmpty => item == null;

        public static InventoryItem GetEmptyItem()
            => new InventoryItem
            {
                item = null,
                quantity = 0,
                itemState = new List<ItemParameter>()
            };
        
        public InventoryItem ChangeQuantity(int newQuantity)
        {
            return new InventoryItem
            {
                item = this.item,
                quantity = newQuantity,
                itemState = new List<ItemParameter>(this.itemState)
            };
        }
    }
}
