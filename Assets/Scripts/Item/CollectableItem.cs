using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CollectableItem : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    

    private bool collected = false;
    private GameObject coin = null;

    public void LoadGame(GameData data)
    {
        data.itemsCollected.TryGetValue(id, out collected);
        if (collected)
        {
            // set the visual of the collected item to false SetActive(false)
        }
    }

    public void SaveGame(GameData data)
    {
        if (data.itemsCollected.ContainsKey(id))
        {
            data.itemsCollected.Remove(id);
        }
        data.itemsCollected.Add(id, collected);
        Debug.Log("saving collactable items");
    }
}
