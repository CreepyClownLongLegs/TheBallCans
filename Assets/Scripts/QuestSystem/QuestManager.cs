using System;
using System.Collections;
using System.Collections.Generic;
using Systems.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager :MonoBehaviour, IDataPersistence
{
    [Header("Config")]
    [SerializeField] private bool loadQuestState = true;
    public static QuestManager Instance {private set; get;}
    private Dictionary<string, Quest> questMap;

    // quest start requirements
    private int currentPlayerLevel;

    private void Awake(){
        if(!Instance){
            Destroy(Instance);
        }
        Instance = this;
    }
    private void Start()
    {
        GameEventsManager.instance.questEvents.onStartQuest += StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest += FinishQuest;
        GameEventsManager.instance.questEvents.onQuestStepStateChange += QuestStepStateChange;

        StartCoroutine(check());
    }


    public void UpdateOnScenesLoaded(){
        CheckRequirements();
        foreach (Quest quest in questMap.Values)
        {
            // initialize any loaded quest steps
            if (quest.state == QuestState.IN_PROGRESS)
            {
                quest.InstantiateCurrentQuestStep(this.transform);
            }
            // broadcast the initial state of all quests on startup
            GameEventsManager.instance.questEvents.QuestStateChange(quest);
        }
    }


    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onStartQuest -= StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest -= AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest -= FinishQuest;
        GameEventsManager.instance.questEvents.onQuestStepStateChange -= QuestStepStateChange;
        SceneLoader.newSceneGrouploaded -= UpdateOnScenesLoaded;
    }

    private Dictionary<string, Quest> CreateQuestMap(GameData gameData)
    {
        // loads all QuestInfoSO Scriptable Objects under the Assets/Resources/Quests folder
        QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quests");
        // Create the quest map
        Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
        foreach (QuestInfoSO questInfo in allQuests)
        {
            if (idToQuestMap.ContainsKey(questInfo.id))
            {
                Debug.LogWarning("Duplicate ID found when creating quest map: " + questInfo.id);
            }
            idToQuestMap.Add(questInfo.id, LoadQuest(questInfo,gameData));
        }
        return idToQuestMap;
    }

    public Quest GetQuestById(string id)
    {
        Quest quest = questMap[id];
        if (quest == null)
        {
            Debug.LogError("ID not found in the Quest Map: " + id);
        }
        return quest;
    }

    private Quest LoadQuest(QuestInfoSO questInfo,GameData data)
    {
        Quest quest = null;

        try 
        {
            // load quest from saved data
            if (data.questMap.ContainsKey(questInfo.id) && loadQuestState)
            {
                string serializedData;
                data.questMap.TryGetValue(questInfo.id, out serializedData);
                QuestData questData = JsonUtility.FromJson<QuestData>(serializedData);
                quest = new Quest(questInfo, questData.state, questData.questStepIndex, questData.questStepStates);
                if (quest.state == QuestState.IN_PROGRESS)
                    {
                        quest.InstantiateCurrentQuestStep(this.transform);
                }
                Debug.Log(serializedData);
            }
            else 
            {
                quest = new Quest(questInfo);
            }
          GameEventsManager.instance.questEvents.QuestStateChange(quest);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load quest with id " + quest.info?.id + ": " + e);
        }
        
        return quest;
    }

    private bool CheckRequirementsMet(Quest quest)
    {
        // start true and prove to be false
        bool meetsRequirements = true;

        // check player level requirements

        // check quest prerequisites for completion
        foreach (QuestInfoSO prerequisiteQuestInfo in quest.info.questPrerequirements)
        {
            if (GetQuestById(prerequisiteQuestInfo.id).state != QuestState.FINISHED)
            {
                meetsRequirements = false;
            }
        }
        Debug.Log(meetsRequirements);
        return meetsRequirements;
    }

    public IEnumerator check(){
        yield return new WaitForSeconds(0.1f);
        LoadGame(DataPersistenceManager.instance.GetGameData());
        UpdateOnScenesLoaded();
        SceneLoader.newSceneGrouploaded += UpdateOnScenesLoaded;
    }

    private void QuestStepStateChange(string id, int stepIndex, QuestStepState questStepState)
    {
        Quest quest = GetQuestById(id);
        quest.StoreQuestStepState(questStepState, stepIndex);
        ChangeQuestState(id, quest.state);
    }

    public void coroutineCheck(Scene scene, LoadSceneMode mode){
        Debug.Log("Loaded Scene" + scene.name);
        if(scene.name.Equals("YourRoomUI")){
            Debug.Log("equals");
            StartCoroutine(check());
        };
    }
    private void CheckRequirements()
    {
        // loop through ALL quests
        foreach (Quest quest in questMap.Values)
        {
            // if we're now meeting the requirements, switch over to the CAN_START state
            if (quest.state == QuestState.REQUIREMENTS_NOT_MET && CheckRequirementsMet(quest))
            {
                ChangeQuestState(quest.info.id, QuestState.CAN_START);
            }else if(quest.state == QuestState.CAN_START){
                ChangeQuestState(quest.info.id, QuestState.CAN_START);
            }else if(quest.state == QuestState.IN_PROGRESS){
                ChangeQuestState(quest.info.id, QuestState.IN_PROGRESS);
            }else if(quest.state == QuestState.CAN_FINISH){
                ChangeQuestState(quest.info.id, QuestState.CAN_FINISH);
            }else if(quest.state == QuestState.FINISHED){
                ChangeQuestState(quest.info.id, QuestState.FINISHED);
            }

            Debug.Log(quest.info.displayName + " " + quest.state);
        }
    }


    private void AdvanceQuest(string id)
    {
        Quest quest = GetQuestById(id);

        // move on to the next step
        quest.MoveToNextStep();

        // if there are more steps, instantiate the next one
        if (quest.CurrentStepExists())
        {
            quest.InstantiateCurrentQuestStep(this.transform);
        }
        // if there are no more steps, then we've finished all of them for this quest
        else
        {
            ChangeQuestState(quest.info.id, QuestState.CAN_FINISH);
        }
    }

    private void FinishQuest(string id)
    {
        Quest quest = GetQuestById(id);
        ChangeQuestState(quest.info.id, QuestState.FINISHED);
        NotificationManager.Instance.showNotification("Quest: [" + quest.info.displayName + "] is finished ! You earned " + quest.info.coins + "dabloons and " + quest.info.playerExpirience + " XP!", NotificationPanelColor.SUCCSES);
        GameEventsManager.instance.goldEvents.GoldGained(quest.info.coins);
        GameEventsManager.instance.playerEvents.ExperienceGained(quest.info.playerExpirience);
    }
    private void StartQuest(string obj)
    {
        Quest quest = GetQuestById(obj);
        quest.InstantiateCurrentQuestStep(this.transform);
        ChangeQuestState(quest.info.id, QuestState.IN_PROGRESS);
    }

    private void ChangeQuestState(string id, QuestState state)
    {
        Quest quest = GetQuestById(id);
        quest.state = state;
        GameEventsManager.instance.questEvents.QuestStateChange(quest);
    }

    private void OnApplicationQuit()
    {
        SaveGame(DataPersistenceManager.instance.GetGameData());
        DataPersistenceManager.instance.SaveGame();
    }

    private void SaveQuest(Quest quest, GameData data)
    {
        try 
        {
            QuestData questData = quest.GetQuestData();
            // serialize using JsonUtility, but use whatever you want here (like JSON.NET)
            string serializedData = JsonUtility.ToJson(questData);
            // saving to PlayerPrefs is just a quick example for this tutorial video,
            // you probably don't want to save this info there long-term.
            // instead, use an actual Save & Load system and write to a file, the cloud, etc..
            if(data.questMap.ContainsKey(quest.info.id)){
                data.questMap[quest.info.id] = serializedData;
            }else {
                data.questMap.Add(quest.info.id, serializedData);
                Debug.Log(serializedData);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save quest with id " + quest.info.id + ": " + e);
        }
    }

    public void LoadGame(GameData data)
    {
        questMap = CreateQuestMap(data);
    }

    public void SaveGame(GameData data)
    {
        foreach (Quest quest in questMap.Values)
        {
            SaveQuest(quest,data);
        }
    }
}
