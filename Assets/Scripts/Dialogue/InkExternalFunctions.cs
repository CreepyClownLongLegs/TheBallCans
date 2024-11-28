using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using Systems.SceneManagement;
using UnityEngine;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("startEpisodeOneKayakingGame", StartEpisodeOneKayakingGame);
        story.BindExternalFunction("startEpisodeOneCookingGame", StartEpisodeOneCookingGame);
        story.BindExternalFunction("GotPasswordFromFatima",GotPasswordFromFatima);
        story.BindExternalFunction("UnlockSerbiaRoom",UnlockSerbiaRoom);
    }

    public void Unbind(Story story) 
    {
        story.UnbindExternalFunction("startEpisodeOneKayakingGame");
        story.UnbindExternalFunction("startEpisodeOneCookingGame");
        story.UnbindExternalFunction("GotPasswordFromFatima");
        story.UnbindExternalFunction("UnlockSerbiaRoom");
    }

    public void StartEpisodeOneKayakingGame(){
        Debug.Log("Starting Kayaking Game");
        _ = SceneLoader.Instance.LoadSceneGroup(6);
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0,0,0);
    }

    public void UnlockSerbiaRoom(){
        EpisodeManager.instance.ChangeDoorValue("Serbia", true);
        EpisodeManager.instance.saveNPCShowVariable("RomaniaNPCKitchen", false);
        EpisodeManager.instance.saveNPCShowVariable("ZoranNPCKitchen", false);
        EpisodeManager.instance.saveNPCShowVariable("RomaniaNPCRoom", true);
        NotificationManager.Instance.showNotification("You've unlocked Zorans Room!", NotificationPanelColor.SUCCSES);
    }

    public void StartEpisodeOneCookingGame(){
        Debug.Log("Starting Cooking Game");
        _ = SceneLoader.Instance.LoadSceneGroup(7);
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(14,-8,0);
    }

    public void GotPasswordFromFatima(){
        DialogueManager.Instance.GotPasswordFromFatima = true;
    }
}
