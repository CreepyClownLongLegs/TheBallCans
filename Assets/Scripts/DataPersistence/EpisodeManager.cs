using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpisodeManager : MonoBehaviour, IDataPersistence
{
    SerializableDictionary<string,bool> doors;
    public bool firstEpisode = true;
    public bool secondEpisode = false;
    public bool EpisodeOneKayakingGameFinished = false;
    public bool EpisodeOneCookingGameFinished = false;
    public static EpisodeManager instance {private set; get;}

    public void LoadGame(GameData data)
    {
        doors = data.doors;
        firstEpisode = data.firstEpisode;
        secondEpisode = data.secondEpisode;
        EpisodeOneKayakingGameFinished = data.EpisodeOneKayakingGameFinished;
        EpisodeOneCookingGameFinished = data.EpisodeOneCookingGameFinished;
        DialogueManager.Instance.EpisodeOneCookingGameFinished = EpisodeOneCookingGameFinished;
        DialogueManager.Instance.EpisodeOneKayakingGameFinished = EpisodeOneKayakingGameFinished;
    }

    public void SaveGame(GameData data)
    {
        data.doors = this.doors;
        data.firstEpisode = firstEpisode;
        data.secondEpisode = secondEpisode;
        data.EpisodeOneKayakingGameFinished = EpisodeOneCookingGameFinished;
        data.EpisodeOneCookingGameFinished = EpisodeOneCookingGameFinished;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
