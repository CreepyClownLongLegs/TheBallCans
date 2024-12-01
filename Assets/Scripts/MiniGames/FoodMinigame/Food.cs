using System.Collections;
using UnityEngine;

public enum FoodType{GOOD, BAD}

public class Food : MonoBehaviour
{
    [SerializeField] public FoodType type;
    [SerializeField] public int points = 0;
    [SerializeField] public FoodSC food = null;
    bool isCollected = false;
    
    private SpriteRenderer sr;

    private void Start()
    {
        StartCoroutine(die());
    }

    private void FixedUpdate()
    {
        if (isCollected)
        {
            //picking up the right food will add points and remove it from the inventory list
            if (type.Equals(FoodType.GOOD))
            {
                FoodInventory.instance.AddFood(this.food);
            }
            else if (type.Equals(FoodType.BAD))
            {
                //Lose health/points
                FoodInventory.instance.AddFood(this.food);
                CookingGameManager.instance.addScorePoints(points);

            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isCollected = true;
        }
    }

    private IEnumerator die()
    {
        yield return new WaitForSeconds(7f);
        Destroy(this.gameObject);
    }
}
