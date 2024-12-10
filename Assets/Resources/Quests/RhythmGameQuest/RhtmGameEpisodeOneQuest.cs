using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhtmGameEpisodeOneQuest : QuestStep
{

    public bool gamePlayed = false;

    private void Start(){
        UpdateState();
        GameEventsManager.instance.playerEvents.rhytmGamePlayed += rhytmGamePlayed;
        onFinishQuest += rhythmGameOver;
    }  
    protected override void SetQuestStepState(string state)
    {
        this.gamePlayed = System.Boolean.Parse(state);
        UpdateState();
    }

    private void rhytmGamePlayed(){
        gamePlayed = true;
        GameEventsManager.instance.playerEvents.rhytmGamePlayed -= rhytmGamePlayed;
        FinishQuestStep();
    }

    private void rhythmGameOver(){
        NotificationManager.Instance.showNotification("Time to go hinks mimimimi!", NotificationPanelColor.SUCCSES);
        onFinishQuest -= rhythmGameOver;
        EpisodeManager.instance.ChangeDoorValue("Romania", false);
        EpisodeManager.instance.ChangeDoorValue("Bosnia", false);
        EpisodeManager.instance.ChangeDoorValue("Serbia", false);
        EpisodeManager.instance.GoToSleepPanel.SetActive(true);
    }
    private void UpdateState()
    {
        string status = "";
        string state = gamePlayed.ToString();

        if(gamePlayed){
            status = "You've been a great help lil fella :)";
        }else{
            status = "Go help the scary looking serbian man!";
        }
        
        if(QuestManager.Instance.GetQuestById(questId).state==QuestState.IN_PROGRESS){
            //just in case
        }

        ChangeState(state, status);
    }
}
