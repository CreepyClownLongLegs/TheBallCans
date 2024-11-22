using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Inventory/Recipe", order = 1)]
public class Recipe : ScriptableObject
{
    [SerializeField]
    public List<FoodSC> foods;

    [SerializeField] public String recipeName;

    public List<FoodSC> GetFoods()
    {
        return foods;
    }
}
