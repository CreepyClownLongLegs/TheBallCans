using UnityEngine;

public class WinCookingGame : QuestStep
{
    bool winCookingGame = false;

    private void Start(){
        UpdateState();
        GameEventsManager.instance.playerEvents.wonCookingGame += WonCookingGame;
    }   
    protected override void SetQuestStepState(string state)
    {
        this.winCookingGame = System.Boolean.Parse(state);
        UpdateState();
        //checkign if its in progress
    }

    private void WonCookingGame(){
        winCookingGame = true;
        GameEventsManager.instance.playerEvents.wonCookingGame -= WonCookingGame;
        EpisodeManager.instance.saveNPCShowVariable("SloveniaNPCKitchen", false);
        EpisodeManager.instance.saveNPCShowVariable("SloveniaNPCLobby", true);
        EpisodeManager.instance.saveNPCShowVariable("BulgariaNPCKitchen", false);
        FinishQuestStep();
    }

    private void UpdateState()
    {
        string status = "";
        string state = winCookingGame.ToString();

        if(winCookingGame){
            status = "You've been a great help lil fella :)";
        }else{
            status = "Go help the lil romanian cook!";
        }
        
        if(QuestManager.Instance.GetQuestById(questId).state==QuestState.IN_PROGRESS){
            Debug.Log("its in progress the cooking");
            EpisodeManager.instance.saveNPCShowVariable("BosniaNPC", false);
            DialogueManager.Instance.CookingQuestAccepted = true;
        }

        ChangeState(state, status);
    }

}
