using UnityEngine;

public class ExpirienceManager : PersistentSingleton<ExpirienceManager>,IDataPersistence
{
    private int playerExpirience = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameEventsManager.instance.playerEvents.onExperienceGained += addExpirience;
    }

    void OnDestroy(){
        GameEventsManager.instance.playerEvents.onExperienceGained -= addExpirience;
    }
    // Update is called once per frame
    public void addExpirience(int EXP){
        Debug.Log("Added " + EXP + "XP");
        this.playerExpirience += EXP;
        SaveGame(DataPersistenceManager.instance.GetGameData());
        DataPersistenceManager.instance.SaveGame();
    }

    public void LoadGame(GameData data)
    {
        this.playerExpirience = DataPersistenceManager.instance.GetGameData().playerExpirience;
    }

    public void SaveGame(GameData data)
    {
        DataPersistenceManager.instance.GetGameData().playerExpirience = this.playerExpirience;
    }
}
