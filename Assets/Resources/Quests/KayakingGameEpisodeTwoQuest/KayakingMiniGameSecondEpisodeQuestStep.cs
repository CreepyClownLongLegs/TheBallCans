using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KayakingMiniGameSecondEpisodeQuestStep : QuestStep
{
    private int memoriesCollected = 0;
    private int memoriesToComplete = 3;
    bool talkedWithFatima = false;
    private void Start()
    {
        StartCoroutine(coroutineUpdateState());
    }

    private void OnDisable()
    {
        KayakingGameManager.MemoryCollectedAction -= MemoryCollected;
    }

    private void MemoryCollected()
    {
        if (memoriesCollected < memoriesToComplete)
        {
            memoriesCollected++;
            UpdateState();
        }

        talkedWithFatima = DialogueManager.Instance.GotPasswordFromFatima;

        if (memoriesCollected >= memoriesToComplete)
        {
            FinishQuestStep();
            EpisodeManager.instance.EpisodeTwoKayakingGameFinished = true;
        }
    }

    private IEnumerator coroutineUpdateState(){
        yield return new WaitForSeconds(0.5f);
        if(EpisodeManager.instance.secondEpisode){
            KayakingGameManager.MemoryCollectedAction += MemoryCollected;
            UpdateState();
        }
    }

    private void UpdateState()
    {
        string state = memoriesCollected.ToString();
        string status = "Collected " + memoriesCollected+ " / " + memoriesToComplete + " memories for completion.";
        if(QuestManager.Instance.GetQuestById("KayakingGameSecondEpisodeQuestInfo").GetQuestData().state == QuestState.IN_PROGRESS){
            //
        }
        ChangeState(state, status);
    }


    protected override void SetQuestStepState(string state)
    {
        this.memoriesCollected = System.Int32.Parse(state);
        UpdateState();
    }
}
