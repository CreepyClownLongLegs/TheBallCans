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
        story.BindExternalFunction("GotPasswordFromFatima",GotPasswordFromFatima);
    }

    public void Unbind(Story story) 
    {
        story.UnbindExternalFunction("startEpisodeOneKayakingGame");
        story.UnbindExternalFunction("GotPasswordFromFatima");
    }

    public void StartEpisodeOneKayakingGame(){
        Debug.Log("Starting Kayaking Game");
        _ = SceneLoader.Instance.LoadSceneGroup(6);
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0,0,0);
    }

    public void GotPasswordFromFatima(){
        DialogueManager.Instance.GotPasswordFromFatima = true;
    }
}
