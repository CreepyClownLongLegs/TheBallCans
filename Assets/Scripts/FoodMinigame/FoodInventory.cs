using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInventory : MonoBehaviour
{
    public List<FoodSC> foods = new List<FoodSC>();

    public delegate void OnFoodChanged();
    public OnFoodChanged onFoodChangedCallback;

    #region Singleton
    public static FoodInventory instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    public void AddFood(FoodSC food)
    {
        foods.Add(food);
        if(onFoodChangedCallback != null)
            onFoodChangedCallback.Invoke();
    }

    public void RemoveFood(FoodSC food)
    {
        foods.Remove(food);
        if (onFoodChangedCallback != null)
            onFoodChangedCallback.Invoke();
    }
}
