using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    [SerializeField] public TextMeshPro collectedPointsVisulsCue;
    [SerializeField] public GameObject gameStartPanel;
    [SerializeField] public GameObject gameOverPanel;
    [SerializeField] public GameObject gameLostPanel;
    [SerializeField] public TextMeshProUGUI GameOverScoreText;
    [SerializeField] public GameObject door;

    public float YRecipeOffset;
    public int pointsCollected = 0;
    public float secondsTheVisualPointsCueIsShown = 1f;
    public int correctOrderExtraPoints = 10;
    private bool gameHasBeenStarted = false;
    private bool gameIsOver = false;

    public static event Action GameOver;
    public static event Action GameStart;

    private Coroutine textCoroutine;

    private int round = 0;
    Vector3 initialPosition ;
 
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

    void Start()
    {
        this.door.SetActive(false);
        CreateRecipePanel();
        initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        gameLostPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameStartPanel.SetActive(true);
        collectedPointsVisulsCue.gameObject.transform.position = new Vector3(initialPosition.x+2,initialPosition.y+1,0);
        collectedPointsVisulsCue.gameObject.SetActive(false);
        InputSystem.interactPressed += ReturnToRoom;
        InputSystem.interactPressed += StartGame;
    }

    private void CreateRecipePanel()
    {
        recipeName.text = recipeFirstRound.recipeName;
        int i = 0;
        foreach(FoodSC foodSC in recipeFirstRound.GetFoods())
        {
            GameObject obj = Instantiate(foodIconPrefab, recipePanel.transform);
            obj.GetComponent<Image>().sprite = foodSC.icon;
            obj.transform.position = new Vector3(obj.transform.position.x, (obj.transform.position.y - i*100) + YRecipeOffset, 0);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = foodSC.name;
            i++;
        }
    }

    public void InventoryUpdater(FoodSC food)
    {
        int itemInOrder = FoodInventory.instance.foods.Count;
        GameObject obj = Instantiate(foodIconPrefab, inventoryPanel.transform);
        obj.GetComponent<Image>().sprite = food.icon;
        if(food.type == FoodType.BAD)
        {
            obj.GetComponent<Image>().color = new Color(0,1,0,1);
        }
        else 
        {
            obj.GetComponent<Image>().color = new Color(1,1,1,1);
        }
        obj.transform.position = new Vector3(((obj.transform.position.x + itemInOrder*75) - 225), obj.transform.position.y, 0);
    }


    public void GameWon()
    {
        if(pointsCollected > 0)
        {
            GameEventsManager.instance.playerEvents.ExperienceGained(pointsCollected);
            NotificationManager.Instance.showNotification("Yipie!! <br> You've unlocked Romanias room! :D", NotificationPanelColor.SUCCSES);
            GameEventsManager.instance.playerEvents.WonCookingGame();
            EpisodeManager.instance.ChangeDoorValue("Romania", true);
            DialogueManager.Instance.EpisodeOneCookingGameFinished = true;
        }
        NotificationManager.Instance.showNotification("Yipie!! <br> You wonzzz! :D", NotificationPanelColor.SUCCSES);
    }

    public void GameLost()
    {
        NotificationManager.Instance.showNotification("Try again :(", NotificationPanelColor.INFO);
        Destroy(collectedPointsVisulsCue.gameObject);
    }

    private IEnumerator showPointsCollectedNow(int points)
    {
        collectedPointsVisulsCue.gameObject.SetActive(true);
        if(points<0)
        {
            collectedPointsVisulsCue.text = "-" + points + " POINTS!";
            collectedPointsVisulsCue.color = Color.red;
            initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            collectedPointsVisulsCue.gameObject.transform.position = new Vector3(initialPosition.x+2,initialPosition.y+1,0);
        } 
        else 
        {
            collectedPointsVisulsCue.text = "+" + points + " POINTS!";
            collectedPointsVisulsCue.color = Color.green;
            initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            collectedPointsVisulsCue.gameObject.transform.position = new Vector3(initialPosition.x+2,initialPosition.y+1,0);
        }
        yield return new WaitForSeconds(secondsTheVisualPointsCueIsShown);
        collectedPointsVisulsCue.gameObject.SetActive(false);
    }

    public void startCoroutinePointsText(int points)
    {
        if(textCoroutine!=null)
        {
            StopCoroutine(textCoroutine);
        }
        textCoroutine = StartCoroutine(showPointsCollectedNow(points));
    }

    private void StartGame()
    {
        if(!gameHasBeenStarted)
        {
            gameHasBeenStarted = true;
            gameStartPanel.SetActive(false);
            InputSystem.interactPressed -= StartGame;
            GameStart?.Invoke();
        }
    }

    private void ReturnToRoom()
    {
        if(gameIsOver)
        {
            this.gameIsOver = false;
            this.gameOverPanel.SetActive(false);
            this.gameLostPanel.SetActive(false);
            InputSystem.interactPressed -= ReturnToRoom;
            this.door.SetActive(true);
        }
    }

    private void SetGameOverPanel()
    {
        string text = "Your final score is: " + score + "<br> You've collected " + FoodInventory.instance.foods.Count +  " ingredients <br> Press 'E' to return";
        this.GameOverScoreText.text = text;
        this.gameOverPanel.SetActive(true);
    }

    public void GameOverCalled(bool lost)
    {
        //checkIf Won or Lost#
        GameOver?.Invoke();
        if(lost)
        {
            //lost
            gameLostPanel.SetActive(true);
            gameIsOver = true;
            GameLost();
        } 
        else 
        {
            //win
            SetGameOverPanel();
            gameIsOver = true;
            GameWon();
        }
    }
}
