using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    }

    private void WonCookingGame(){
        winCookingGame = true;
        GameEventsManager.instance.playerEvents.wonCookingGame -= WonCookingGame;
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

        ChangeState(state, status);
    }

}
