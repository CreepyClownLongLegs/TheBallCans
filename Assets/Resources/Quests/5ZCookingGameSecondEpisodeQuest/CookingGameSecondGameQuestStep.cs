using UnityEngine;

public class CookingGameSecondGameQuestStep : QuestStep
{
    bool winCookingGame = false;

    private void Start(){
        UpdateState();
        GameEventsManager.instance.playerEvents.wonCookingGame += WonCookingGame;
        EpisodeManager.instance.EpisodeTwoCookingGameFinished = false;
        DialogueManager.Instance.EpisodeTwoCookingGameFinished = false;
    }   
    protected override void SetQuestStepState(string state)
    {
        this.winCookingGame = System.Boolean.Parse(state);
        UpdateState();
        //checkign if its in progress
    }

    private void WonCookingGame(){
        if(EpisodeManager.instance.secondEpisode){
            winCookingGame = true;
            GameEventsManager.instance.playerEvents.wonCookingGame -= WonCookingGame;
            FinishQuestStep();
        }
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
            Debug.Log("its in progress the cooking of Second Episode");
            EpisodeManager.instance.CookingQuestAcceptedEpisodeTwo = true;
            DialogueManager.Instance.CookingQuestAcceptedSecondEpisode = true;
            //bullshit solution look at it at a later time maybe
            EpisodeManager.instance.EpisodeTwoCookingGameFinished = false;
            DialogueManager.Instance.EpisodeTwoCookingGameFinished = false;
            EpisodeManager.instance.saveNPCShowVariable("RomaniaNPCRoom", false);
            EpisodeManager.instance.saveNPCShowVariable("RomaniaNPCKitchen", true);
            EpisodeManager.instance.saveNPCShowVariable("SloveniaNPCLobby", false);
            EpisodeManager.instance.saveNPCShowVariable("SloveniaNPCKitchen", false);
            EpisodeManager.instance.saveNPCShowVariable("BulgariaNPCKitchen", false);
        }

        ChangeState(state, status);
    }
}
