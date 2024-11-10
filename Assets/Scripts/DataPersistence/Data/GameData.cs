using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> itemsCollected;
    public PlayerData playerMoney;
    public int playerExpirience;
    internal object playerData;

    public GameData()
    {
        playerPosition = Vector3.zero;
        itemsCollected = new SerializableDictionary<string, bool>();
        playerMoney.money = 0;
        playerExpirience = 0;
    }
}
