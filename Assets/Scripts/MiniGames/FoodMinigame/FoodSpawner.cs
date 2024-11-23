using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject foodSpawnPrefab;
    [SerializeField] public List<FoodSC> badFoods;
    public float minX;
    public float maxX;
    public float valueY;
    public float minSpawningTime = 0.5f;
    public float maxSpawningTime = 0.8f;
    private float randomSpawningTime;
    public float timer = 0f;
    public float foodTimer = 0f;
    private bool spawn = true;
    private List<FoodSC> allFoods;

    // Update is called once per frame
    void Start()
    {
        FoodInventory.instance.badFoods = badFoods;
        CookingGameManager.GameOver += dontSpawn;
        CookingGameManager.GameStart += startToSpawn;
        allFoods = CookingGameManager.instance.recipeFirstRound.GetFoods();
        foreach(FoodSC food in badFoods)
        {
            allFoods.Add(food);
        }
    }

    private void OnDestroy()
    {
        CookingGameManager.GameOver -= dontSpawn;
        CookingGameManager.GameStart -= startToSpawn;
    }

    void FixedUpdate()
    {
        if(foodTimer > randomSpawningTime && spawn)
        {
            randomiseFoodSpawning();
            foodTimer = 0f;
            int score = CookingGameManager.instance.pointsCollected ++;
            //TODO: make later
            //CookingGameManager.instance.scoreText.text = "Score : " + score; 
        }
        foodTimer += 0.01f;
    }

    public void dontSpawn()
    {
        this.spawn = false;
    }

    private void startToSpawn()
    {
        this.spawn = true;
    }

    public void GetChildArray()
    {
        GetComponentsInChildren<FoodSpawner>();
    }


    private void SpawnFood(FoodSC foodSC)
    {
        float randomX = Random.Range(minX, maxX);
        this.randomSpawningTime = Random.Range(minSpawningTime,maxSpawningTime);
        GameObject obj = Instantiate(foodSpawnPrefab, this.transform);
        obj.GetComponent<Food>().points = foodSC.points;
        obj.GetComponent<Food>().type = foodSC.type;
        obj.GetComponent<Food>().food = foodSC;
        obj.GetComponent<SpriteRenderer>().sprite = foodSC.icon;
        //setting visual cue
        if(foodSC.type == FoodType.BAD)
        {
            obj.GetComponent<SpriteRenderer>().color = Color.green;
        }
        obj.transform.position = new Vector3(randomX, valueY, 0f);
    }

    private void randomiseFoodSpawning()
    {
        int indexOfFood = Random.Range(0,allFoods.Count-1);
        SpawnFood(allFoods[indexOfFood]);
    }
}
