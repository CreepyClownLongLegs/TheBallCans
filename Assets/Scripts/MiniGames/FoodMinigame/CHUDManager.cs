using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class HUDManager : MonoBehaviour
{
    public Image foodsContainer;
    public TextMeshProUGUI scoreText;
 
    public void Start()
    {
        scoreText.text = "Score: 0";
        CookingGameManager.instance.onScoreChangedCallback += UpdateScore;
        FoodInventory.instance.onFoodChangedCallback    += UpdateInvItems;
    }
 
    private void UpdateScore()
    {
        scoreText.text = "Score: " + CookingGameManager.instance.score;
    }
 
    private void UpdateInvItems()
    {
        ClearAllItemsSlots();
 
        FillAllItemsSlots();
    }
 
    private void ClearAllItemsSlots()
    {
        for(int i = 0; i < foodsContainer.transform.childCount; i++)
        {
            foodsContainer.transform.GetChild(i).GetComponent<Image>().sprite = null;
            foodsContainer.transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
    }
 
    private void FillAllItemsSlots()
    {
        if (FoodInventory.instance.foods.Count > 0)
        {
            for (int i = 0; i < FoodInventory.instance.foods.Count; i++)
            {
                if (FoodInventory.instance.foods[i] != null)
                {
                    foodsContainer.transform.GetChild(i).GetComponent<Image>().sprite = FoodInventory.instance.foods[i].icon;
                    foodsContainer.transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                else
                {
                    foodsContainer.transform.GetChild(i).GetComponent<Image>().sprite = null;
                    foodsContainer.transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
            }
        }
    }
 
}