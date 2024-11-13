using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private InventorySO inventoryData;

    CharacterController2D characterController;

    void Awake()
    {
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            Debug.Log("Item picked up!");
            inventoryData.AddItem(item.InventoryItem);
            item.DestroyItem();
        }
    }
}
