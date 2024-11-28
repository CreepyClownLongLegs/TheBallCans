using System;
using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using UnityEngine;
using UnityEngine.AI;

public class Item : MonoBehaviour
{
    [field: SerializeField]
    public ItemSO InventoryItem {get; private set;}

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float duration = 0.3f;
    public bool isCollected = false;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = InventoryItem.ItemImage; 
        foreach(InventoryItem item in PickUpSystem.instance.GetInventoryItems()){
            if(item.item!=null){
                if(item.item?.name == InventoryItem.name){
                    Debug.Log("they are the same");
                    isCollected = true;
                }
            }
        }

        if(isCollected){
            this.gameObject.SetActive(false);
        }
    }

    public void DestroyItem()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(AnimateItemPickup());
    }

    private IEnumerator AnimateItemPickup()
    {
        audioSource.Play();
        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.zero;
        float currentTime = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, endScale, currentTime / duration);
            yield return null;
        }
        Destroy(gameObject);
    }
    
}
