
using UnityEngine;

public class RhythmGameEpisodeTwo : QuestStep
{
    public bool gamePlayed = false;

    private void Start(){
        UpdateState();
        GameEventsManager.instance.playerEvents.rhytmGamePlayed += rhytmGamePlayed;
    }  
    protected override void SetQuestStepState(string state)
    {
        this.gamePlayed = System.Boolean.Parse(state);
        UpdateState();
    }

    private void rhytmGamePlayed(){
        if(EpisodeManager.instance.secondEpisode){
            gamePlayed = true;
            GameEventsManager.instance.playerEvents.rhytmGamePlayed -= rhytmGamePlayed;
            EpisodeManager.instance.ChangeDoorValue("Bosnia", true);
            EpisodeManager.instance.saveNPCShowVariable("BosniaNPC", true);
            EpisodeManager.instance.EpisodeTwoRhytmGameFinished = true;
            Debug.Log("Episode TWo Rhytm Game Finished");
            FinishQuestStep();
        }
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
            EpisodeManager.instance.ChangeDoorValue("Serbia", true);
            EpisodeManager.instance.saveNPCShowVariable("ZoranNPCRoom",true);
            EpisodeManager.instance.saveNPCShowVariable("ZlatanNPCLobby",false);
        }

        ChangeState(state, status);
    }
}
