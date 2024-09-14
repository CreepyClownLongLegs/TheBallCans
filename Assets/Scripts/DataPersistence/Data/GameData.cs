using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> itemsCollected;
    public GameData()
    {
        playerPosition = Vector3.zero;
        itemsCollected = new SerializableDictionary<string, bool>();
    }
}
