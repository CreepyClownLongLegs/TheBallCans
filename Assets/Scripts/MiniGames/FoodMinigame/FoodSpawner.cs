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
    private bool spawn = false;
    private List<FoodSC> allFoods = new List<FoodSC>();

    private List<FoodSC> cookingManagerList = new List<FoodSC>();

    // Update is called once per frame
    void Start()
    {
        cookingManagerList = CookingGameManager.instance.recipe.GetFoods();
        FoodInventory.instance.badFoods = badFoods;
        CookingGameManager.GameOver += dontSpawn;
        CookingGameManager.GameStart += startToSpawn;
        foreach(FoodSC foodSC in cookingManagerList){
            allFoods.Add(foodSC);
            Debug.Log("Food " + foodSC.name + "added");
        }
        foreach(FoodSC food in badFoods)
        {
            allFoods.Add(food);
            Debug.Log("Food " + food.name + "added");
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
