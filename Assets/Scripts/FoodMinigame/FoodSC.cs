using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType{GOOD, BAD}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 1)]
public class FoodSC : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon;
    public FoodType type;

    public virtual void Use()
    {

    }

    public virtual void Drop()
    {
        //FoodInventory.instance.RemoveItem();
    }
}
