using System;
using UnityEngine;

public class QuestEvents
{
    
    public event Action<string, int, QuestStepState> onQuestStepStateChange;
    public event Action<string> onStartQuest;
    public void StartQuest(string id)
    {
        onStartQuest.Invoke(id);
    }

    public event Action<string> onAdvanceQuest;
    public void AdvanceQuest(string id)
    {
        onAdvanceQuest.Invoke(id);
    }

    public event Action<string> onFinishQuest;
    public void FinishQuest(string id)
    {
        onFinishQuest.Invoke(id);
    }

    public event Action<Quest> onQuestStateChange;
    public void QuestStateChange(Quest quest)
    {
        onQuestStateChange?.Invoke(quest);
    }

    public void QuestStepStateChange(string id, int stepIndex, QuestStepState questStepState)
    {
        if (onQuestStepStateChange != null)
        {
            onQuestStepStateChange(id, stepIndex, questStepState);
        }
    }
}
