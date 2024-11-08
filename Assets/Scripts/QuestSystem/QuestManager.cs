using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private bool loadQuestState = true;

    private Dictionary<string, Quest> questMap;

    // quest start requirements
    private int currentPlayerLevel;

    private void Awake()
    {
        questMap = CreateQuestMap();
        Quest quest = GetQuestById("CollectCoinsQuest");
        Debug.Log("now");
    }

    private void Start()
    {
        GameEventsManager.instance.questEvents.onStartQuest += StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest += FinishQuest;
        StartCoroutine(check());
    }


    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onStartQuest -= StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest -= AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest -= FinishQuest;
    }

    private Dictionary<string, Quest> CreateQuestMap()
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
            idToQuestMap.Add(questInfo.id, LoadQuest(questInfo));
        }
        return idToQuestMap;
    }

    private Quest GetQuestById(string id)
    {
        Quest quest = questMap[id];
        if (quest == null)
        {
            Debug.LogError("ID not found in the Quest Map: " + id);
        }
        return quest;
    }

        private Quest LoadQuest(QuestInfoSO questInfo)
    {
        Quest quest = null;

        /*
        try 
        {
            // load quest from saved data
            if (PlayerPrefs.HasKey(questInfo.id) && loadQuestState)
            {
                string serializedData = PlayerPrefs.GetString(questInfo.id);
            }
            // otherwise, initialize a new quest
            else 
            {
                quest = new Quest(questInfo);


          GameEventsManager.instance.questEvents.QuestStateChange(quest);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load quest with id " + quest.info.id + ": " + e);
        }
        */
        quest = new Quest(questInfo);
        return quest;
    }

    private bool CheckRequirementsMet(Quest quest)
    {
        // start true and prove to be false
        bool meetsRequirements = true;

        // check player level requirements

        // check quest prerequisites for completion
        Debug.Log("Quest requirements:" + quest.info.questPrerequirements);
        foreach (QuestInfoSO prerequisiteQuestInfo in quest.info.questPrerequirements)
        {
                    Debug.Log("Quest requirements:" + prerequisiteQuestInfo.coins);
            if (GetQuestById(prerequisiteQuestInfo.id).state != QuestState.FINISHED)
            {
                meetsRequirements = false;
            }
        }
        Debug.Log(meetsRequirements);
        return meetsRequirements;
    }

    private IEnumerator check(){
        yield return new WaitForSeconds(0.2f);
        CheckRequirements();
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
            }
        }
    }

    private void FinishQuest(string obj)
    {
        Debug.Log("Started");
    }

    private void AdvanceQuest(string obj)
    {
        Debug.Log("Started");
    }

    private void StartQuest(string obj)
    {
        Debug.Log("Started");
    }

    private void ChangeQuestState(string id, QuestState state)
    {
        Quest quest = GetQuestById(id);
        Debug.Log("Change state");
        quest.state = state;
        Debug.Log(state);
        GameEventsManager.instance.questEvents.QuestStateChange(quest);
    }
}
