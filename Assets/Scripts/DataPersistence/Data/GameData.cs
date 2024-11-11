using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> itemsCollected;
    public PlayerData playerMoney = new PlayerData();
    public int playerExpirience;
    internal object playerData;
    public SerializableDictionary<string, bool> coinsCollected;

    public GameData()
    {
        playerPosition = Vector3.zero;
        itemsCollected = new SerializableDictionary<string, bool>();
        playerMoney.money = 0;
        playerExpirience = 0;
        coinsCollected = new SerializableDictionary<string, bool>();
    }
}
