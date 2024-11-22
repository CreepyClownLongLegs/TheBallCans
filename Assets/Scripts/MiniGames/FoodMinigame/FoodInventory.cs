using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInventory : MonoBehaviour
{
    [SerializeField]
    public List<FoodSC> foods = new List<FoodSC>();

    public delegate void OnFoodChanged();
    public OnFoodChanged onFoodChangedCallback;

    #region Singleton
    public static FoodInventory instance;

    void Awake()
    {
        if (instance!=null)
        {
            Destroy(instance);
        }
        instance = this;
    }
    #endregion


    //collecting the right food that is listed, will remove it from the "inventory" list
    public void AddFood(FoodSC food)
    {
        if(foods.Contains(food))
            return;
        else
            foods.Add(food);
            CookingGameManager.instance.InventoryUpdater(food);
            if (onFoodChangedCallback != null)
                onFoodChangedCallback.Invoke();
    }

}