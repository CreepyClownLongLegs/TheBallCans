using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
private bool isFinished = false;
    private string questId;
    private int stepIndex;

protected void FinishQuestStep(){
    if(!isFinished){
        isFinished = true;
        Destroy(this.gameObject);
    }
}

    public void InitializeQuestStep(string questId, int stepIndex, string questStepState)
    {
        this.questId = questId;
        this.stepIndex = stepIndex;
        if (questStepState != null && questStepState != "")
        {
            SetQuestStepState(questStepState);
        }
    }

    protected abstract void SetQuestStepState(string state);
}
