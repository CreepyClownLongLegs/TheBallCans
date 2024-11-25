using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class FoodInventory : MonoBehaviour
{
    [SerializeField]
    public List<FoodSC> foods = new List<FoodSC>();

    public List<FoodSC> badFoods = new List<FoodSC>();

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

    public void AddFood(FoodSC food)
    {
        if(foods.Contains(food))
        {
            CookingGameManager.instance.addScorePoints(food.points);
            CookingGameManager.instance.startCoroutinePointsText(food.points);
            return;
        }
        else
        {
            CheckIfUnnecasseryFoodCollected(food);
        }
    }

    public void CheckIfUnnecasseryFoodCollected(FoodSC foodSC)
    {
        foods.Add(foodSC);
        CookingGameManager.instance.InventoryUpdater(foodSC);

        if(badFoods.Contains(foodSC))
        {
            Debug.Log("Wrong Food");
            NotificationManager.Instance.showNotification("Wrong item Collected!!",NotificationPanelColor.WARNING);
            CookingGameManager.instance.addScorePoints(-foodSC.points);
            CookingGameManager.instance.startCoroutinePointsText(-foodSC.points);
        }
        else
        {
            CookingGameManager.instance.addScorePoints(foodSC.points);
            CookingGameManager.instance.startCoroutinePointsText(foodSC.points);
            CompareOrderOnCollection(foodSC);
        }
            EnoughFoodsCollected();
            if (onFoodChangedCallback != null)
                onFoodChangedCallback.Invoke();
    }

    public void CompareOrderOnCollection(FoodSC foodSC)
    {
        int indexInInvetory = foods.IndexOf(foodSC);
        int indexInRecipe = CookingGameManager.instance.recipeFirstRound.GetFoods().IndexOf(foodSC);
        Debug.Log("Correct Order");
        if(indexInInvetory == indexInRecipe)
        {
            NotificationManager.Instance.showNotification("Awesomesauce!! Food collected in correct order! <br> Double points for you!",NotificationPanelColor.SUCCSES);
            CookingGameManager.instance.addScorePoints(foodSC.points);
        }
    }

    public void EnoughFoodsCollected()
    {
        if(foods.Count == 5)
        {
            //won
            if(CheckIfEnoughFoodsCollected())
            {
                //lost
                CookingGameManager.instance.GameOverCalled(true);
            }
            else
            {
                //lost
                CookingGameManager.instance.GameOverCalled(false);
            }
        }
        //check if 4/5 items were collected
    }

    public bool CheckIfEnoughFoodsCollected()
    {
        int wrongItems = 0;
        foreach (FoodSC food in foods)
        {
            if(!CookingGameManager.instance.recipeFirstRound.GetFoods().Contains(food))
            {
                wrongItems++;
            }
        }
        return wrongItems >= 2;
    }

}