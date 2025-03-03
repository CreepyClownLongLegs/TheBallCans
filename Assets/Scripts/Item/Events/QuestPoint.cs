using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class QuestPoint : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;

    private bool playerIsNear = false;
    private string questId;
    private QuestState currentQuestState;

    private QuestIcon questIcon;

    private void Awake() 
    {
        questId = questInfoForPoint.id;
        questIcon = GetComponentInChildren<QuestIcon>();
        Debug.Log("Subscribed");
    }

    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange += QuestStateChange;
        InputSystem.interactPressed += SubmitPressed;

    }

    void Start(){
        questIcon.SetState(QuestManager.Instance.GetQuestById(questInfoForPoint.id).state, startPoint, finishPoint);
    }



    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
        InputSystem.interactPressed -= SubmitPressed;
    }

    private void SubmitPressed()
    {
        if(finishPoint && currentQuestState.Equals(QuestState.CAN_START)){
            return;
        }
        if (!playerIsNear)
        {
            return;
        }
        Quest quest = QuestManager.Instance.GetQuestById(questInfoForPoint.id);
        // start or finish a quest
        if (currentQuestState.Equals(QuestState.CAN_START) && startPoint)
        {
            NotificationManager.Instance.showNotification("Quest: [" + questInfoForPoint.displayName + "] has been started!", NotificationPanelColor.INFO);
            GameEventsManager.instance.questEvents.StartQuest(questId);
            //return so it doesnt check the other else ifs
            return;
        } else if (currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint)
        {
            GameEventsManager.instance.questEvents.FinishQuest(questId);
            return;
        } 
        
        if (currentQuestState.Equals(QuestState.IN_PROGRESS) && finishPoint)
        {
            NotificationManager.Instance.showNotification(quest.GetFullStatusText(), NotificationPanelColor.INFO);
        }
    }

    private void QuestStateChange(Quest quest)
    {
        // only update the quest state if this point has the corresponding quest
        if (quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
            questIcon.SetState(currentQuestState, startPoint, finishPoint);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            playerIsNear = false;
       
}
}
}
