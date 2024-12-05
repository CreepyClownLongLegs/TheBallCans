using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpisodeManager : MonoBehaviour, IDataPersistence
{
    SerializableDictionary<string,bool> doors;
    public SerializableDictionary<string,bool> npcs;
    public bool firstEpisode = true;
    public bool secondEpisode = false;
    public bool EpisodeOneKayakingGameFinished = false;
    public bool EpisodeOneCookingGameFinished = false;
    public bool EpisodeOneRhytmGameFinished = false;
    public bool CookingQuestAcceptedEpisodeOne = false;
    public bool CookingQuestAcceptedEpisodeTwo = false;
    public bool EpisodeTwoKayakingGameFinished = false;
    public bool EpisodeTwoCookingGameFinished = false;
    public bool EpisodeTwoRhytmGameFinished = false;
    public bool FirstTimeInRomaniaRoom = false;
    public bool FirstTimeInBosniaRoom = false;
    public bool FirstTimeInSerbiaRoom = false;
    public bool gotMixer = false;
    public bool gotSlingshot = false;
    public static EpisodeManager instance {private set; get;}

    public void LoadGame(GameData data)
    {
        doors = data.doors;
        npcs = data.npcs;
        firstEpisode = data.firstEpisode;
        secondEpisode = data.secondEpisode;
        CookingQuestAcceptedEpisodeOne = data.CookingQuestAcceptedEpisodeOne;
        EpisodeOneKayakingGameFinished = data.EpisodeOneKayakingGameFinished;
        EpisodeOneCookingGameFinished = data.EpisodeOneCookingGameFinished;
        EpisodeOneRhytmGameFinished = data.EpisodeOneRhytmGameFinished;
        EpisodeTwoRhytmGameFinished = data.EpisodeTwoRhytmGameFinished;
        EpisodeTwoCookingGameFinished = data.EpisodeTwoCookingGameFinished;
        CookingQuestAcceptedEpisodeTwo = data.CookingQuestAcceptedEpisodeTwo;
        FirstTimeInBosniaRoom = data.FirstTimeInBosniaRoom;
        FirstTimeInRomaniaRoom = data.FirstTimeInRomaniaRoom;
        FirstTimeInSerbiaRoom = data.FirstTimeInSerbiaRoom;
        gotMixer = data.hasMixer;
        gotSlingshot = data.gotSlingshot;
        DialogueManager.Instance.EpisodeOneCookingGameFinished = EpisodeOneCookingGameFinished;
        DialogueManager.Instance.EpisodeTwoCookingGameFinished = EpisodeTwoCookingGameFinished;
        Debug.Log("Cookign game second round finished : " + EpisodeTwoCookingGameFinished);
        DialogueManager.Instance.EpisodeOneKayakingGameFinished = EpisodeOneKayakingGameFinished;
        DialogueManager.Instance.CookingQuestAccepted = CookingQuestAcceptedEpisodeOne;
        DialogueManager.Instance.CookingQuestAcceptedSecondEpisode =CookingQuestAcceptedEpisodeTwo;
    }

    public void SaveGame(GameData data)
    {
        data.CookingQuestAcceptedEpisodeOne = CookingQuestAcceptedEpisodeOne;
        data.doors = this.doors;
        data.npcs = this.npcs;
        data.gotSlingshot = gotSlingshot;
        data.firstEpisode = firstEpisode;
        data.secondEpisode = secondEpisode;
        data.EpisodeOneKayakingGameFinished = EpisodeOneKayakingGameFinished;
        data.EpisodeOneCookingGameFinished = EpisodeOneCookingGameFinished;
        data.EpisodeOneRhytmGameFinished = EpisodeOneRhytmGameFinished;
        data.CookingQuestAcceptedEpisodeTwo = CookingQuestAcceptedEpisodeTwo;
        data.FirstTimeInBosniaRoom = FirstTimeInBosniaRoom;
        data.FirstTimeInRomaniaRoom = FirstTimeInRomaniaRoom;
        data.FirstTimeInSerbiaRoom = FirstTimeInSerbiaRoom;
        data.EpisodeTwoCookingGameFinished = EpisodeOneCookingGameFinished;
        data.EpisodeTwoKayakingGameFinished = EpisodeTwoKayakingGameFinished;
        data.EpisodeTwoRhytmGameFinished = EpisodeTwoRhytmGameFinished;
        data.hasMixer = gotMixer;
    }

    public void saveNPCShowVariable(string ID, bool Value){
        if(npcs.ContainsKey(ID)){
            npcs[ID] = Value;
        } else {
            npcs.Add(ID,Value);
        }
    }

    void Awake(){
        if(instance!=null){
            Destroy(instance);
        }
        instance = this;
    }

    public bool DoorExistsInDictionary(string door){
        return doors.ContainsKey(door);
    }

    public bool GetDoorValue(string door){
        bool canEnter;
        doors.TryGetValue(door, out canEnter);
        return canEnter;
    }

    public void ChangeDoorValue(string door, bool newValue){
        doors[door]= newValue;
        SaveGame(DataPersistenceManager.instance.GetGameData());
        DataPersistenceManager.instance.SaveGame();
    }


}
