using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public bool firstEpisode;
    public bool secondEpisode;
    public bool EpisodeOneKayakingGameFinished;
    public bool EpisodeOneCookingGameFinished;
    public bool CookingQuestAcceptedEpisodeOne;
    public bool EpisodeOneRhytmGameFinished;
    public bool EpisodeTwoKayakingGameFinished;
    public bool EpisodeTwoCookingGameFinished;
    public bool CookingQuestAcceptedEpisodeTwo;
    public bool EpisodeTwoRhytmGameFinished;
    public bool FirstTimeInRomaniaRoom;
    public bool FirstTimeInBosniaRoom;
    public bool FirstTimeInSerbiaRoom;
    public bool hasMixer;
    public Vector3 playerPosition;
    public PlayerData playerMoney = new PlayerData();
    public int playerExpirience;
    internal object playerData;
    public SerializableDictionary<string,bool> doors;
    public SerializableDictionary<string, bool> coinsCollected;
    public SerializableDictionary<string, bool> itemsCollected;
    public SerializableDictionary<string, string> questMap;
    public SerializableDictionary<string,bool> npcs;

    public GameData()
    {
        firstEpisode = true;
        secondEpisode = false;
        EpisodeOneKayakingGameFinished = false;
        EpisodeOneCookingGameFinished = false;
        CookingQuestAcceptedEpisodeOne = false;
        EpisodeOneRhytmGameFinished = false;

        EpisodeTwoKayakingGameFinished = false;
        EpisodeTwoCookingGameFinished = false;
        CookingQuestAcceptedEpisodeTwo = false;
        EpisodeTwoRhytmGameFinished = false;
        hasMixer = false;

        FirstTimeInRomaniaRoom = false;
        FirstTimeInRomaniaRoom = false;
        FirstTimeInSerbiaRoom = false;
        playerPosition = Vector3.zero;
        playerMoney.money = 0;
        playerExpirience = 0;
        doors = new SerializableDictionary<string, bool>();
        npcs = new SerializableDictionary<string, bool>();
        coinsCollected = new SerializableDictionary<string, bool>();
        itemsCollected = new SerializableDictionary<string, bool>();
        questMap = new SerializableDictionary<string, string>();

        //setting initial Data For Doors
        doors.Add("Romania", false);
        doors.Add("Bosnia", false);
        doors.Add("Serbia", false);

        //setting initial Data For NPCS
        npcs.Add("RomaniaNPCRoom", false);

    }
}
