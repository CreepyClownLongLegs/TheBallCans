using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    public InventorySO inventoryData;
    [SerializeField] public ItemSO iron;
    [SerializeField] public ItemSO spoon;
    [SerializeField] public ItemSO mixer;
    [SerializeField] public ItemSO slingshot;
    [SerializeField] public ItemSO laserGun;
    CharacterController2D characterController;
    public static PickUpSystem instance {get; private set;}

    void Awake()
    {
        if(instance!=null){
            Destroy(instance);
        }
        instance = this;
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>(); 
    }

    void Start(){
        inventoryData.Initialize();
        StartCoroutine(startCoroutineLoadGame());
    }

    private IEnumerator startCoroutineLoadGame(){
        yield return new WaitForSeconds(0.2f);
        inventoryData.LoadGame(DataPersistenceManager.instance.GetGameData());
    }

    public List<InventoryItem> GetInventoryItems(){
        return inventoryData.GetInventoryItems();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Item")){
            return;
        }
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            Debug.Log("Item picked up!");
            NotificationManager.Instance.showNotification("You've picked up a " + item.InventoryItem.name, NotificationPanelColor.INFO);
            inventoryData.AddItem(item.InventoryItem);
            item.DestroyItem();
            SaveGameOnItemPickup();
        }
    }

    public void SaveGameOnItemPickup()
    {
        inventoryData.SaveGame(DataPersistenceManager.instance.GetGameData());
        DataPersistenceManager.instance.SaveGame();
    }

    void OnApplicationQuit(){
        SaveGameOnItemPickup();
    }


}
