using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public enum PickableType {FOOD, BADFOOD}

public class Food : MonoBehaviour
{
    [SerializeField] private PickableType type;
    [SerializeField] private int points = 0;
    //[SerializeField] ItemSC item = null;
    bool isCollected = false;

    private void Update()
    {
        if (isCollected)
        {
            if (type.Equals(PickableType.FOOD))
            {
                //GameManager.instance.addScorePoints(points);
                //FoodInventory.instance.AddItem(item);
            }
            else if (type.Equals(PickableType.BADFOOD))
            {
                //GameManager.instance.removeScorePoints(points);
                //FoodInventory.instance.AddItem(item);
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
}
