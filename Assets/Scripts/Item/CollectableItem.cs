using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    
    // use GUID if you want random id name, for now manual naming of Items will be done
    /* [ContextMenu("Generate guid for id")]

    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    } */

    private bool collected = false;

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
    }
}
