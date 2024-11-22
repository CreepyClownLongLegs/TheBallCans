using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookingGameManager : MonoBehaviour
{
    public int score = 0;
    public delegate void OnScoreChangedCallback();
    public OnScoreChangedCallback onScoreChangedCallback;
    [SerializeField]
    public Recipe recipeFirstRound;

    [SerializeField] private GameObject recipePanel;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject foodIconPrefab;
    [SerializeField] private TextMeshProUGUI recipeName;
    [SerializeField] public TextMeshProUGUI scoreText;

    public float YRecipeOffset;
    public int pointsCollected = 0;

    public static event Action GameOver;
    public static event Action GameStart;

    private int round = 0;
 
    #region Singleton
    public static CookingGameManager instance { get; private set; }
 
    void Awake()
    {
        if (instance!=null)
        {
            Destroy(instance);
        }
        instance = this;
    }
    #endregion Singleton
 
    public void addScorePoints(int points)
    {
        score += points;
        onScoreChangedCallback.Invoke();
    }

    private void Start()
    {
        CreateRecipePanel();
    }

    private void CreateRecipePanel()
    {
        recipeName.text = recipeFirstRound.recipeName;
        int i = 0;
        foreach(FoodSC foodSC in recipeFirstRound.GetFoods()){
            GameObject obj = Instantiate(foodIconPrefab, recipePanel.transform);
            obj.GetComponent<Image>().sprite = foodSC.icon;
            obj.transform.position = new Vector3(obj.transform.position.x, (obj.transform.position.y + i*100) - YRecipeOffset, 0);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = foodSC.name;
            i++;
        }
    }

    public void InventoryUpdater(FoodSC food)
    {
        int itemInOrder = FoodInventory.instance.foods.Count;
        GameObject obj = Instantiate(foodIconPrefab, inventoryPanel.transform);
        obj.GetComponent<Image>().sprite = food.icon;
        obj.transform.position = new Vector3(((obj.transform.position.x + itemInOrder*75) - 225), obj.transform.position.y, 0);
    }

    public void GameWon()
    {
        GameEventsManager.instance.playerEvents.ExperienceGained(pointsCollected);
        NotificationManager.Instance.showNotification("You collected all the ingredients!", NotificationPanelColor.SUCCSES);
    }

    public void GameOverCalled()
    {
        GameEventsManager.instance.playerEvents.ExperienceGained(pointsCollected);
        NotificationManager.Instance.showNotification("Try again :(", NotificationPanelColor.INFO);
    }
}
