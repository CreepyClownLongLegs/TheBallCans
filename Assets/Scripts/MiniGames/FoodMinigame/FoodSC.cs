using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Food Item", menuName = "Inventory/FoodItem", order = 1)]
public class FoodSC : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon;
    public FoodType type;
    public int points = 5;

    public virtual void Use()
    {

    }

    public virtual void Drop()
    {
        //FoodInventory.instance.RemoveItem();
    }
}
