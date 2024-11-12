using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField]
    private UIInventoryPage inventoryUI;
    public int inventorySize = 10;
    
    
    private void Start()
    {
        inventoryUI.InitializeInventoryUI(inventorySize);
        InputSystem.inventoryCalled += InventoryCalled;
    }

    private void OnDestroy(){
        InputSystem.inventoryCalled -= InventoryCalled;
    }

    private void InventoryCalled(){
        if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
            }
            else
            {
                inventoryUI.Hide();
                //wont work if we want to freeze time (imo we dont need to freeze time)
            }
    }
}
