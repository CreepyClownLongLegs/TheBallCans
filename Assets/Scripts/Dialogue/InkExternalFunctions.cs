using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using Inventory.Model;
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
        story.BindExternalFunction("takeIron", TakeIron);
        story.BindExternalFunction("takeSpoon", TakeSpoon);
        story.BindExternalFunction("giveMixer", GiveMixer);
        story.BindExternalFunction("giveSpoon", GiveSpoon);
        story.BindExternalFunction("giveIron", GiveIron);
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

    public void GiveMixer()
    {
        PickUpSystem.instance.inventoryData.AddItem(PickUpSystem.instance.mixer);
        NotificationManager.Instance.showNotification("Mixer has been added to your inventory", NotificationPanelColor.INFO);
    }

    public void TakeIron()
    {
        PickUpSystem.instance.inventoryData.RemoveItemWithName("Iron");
        DialogueManager.Instance.hasIron = false;
        NotificationManager.Instance.showNotification("Iron has been removed from your inventory", NotificationPanelColor.INFO);
    }

    public void TakeSpoon()
    {
        PickUpSystem.instance.inventoryData.RemoveItemWithName("Spoon");
        DialogueManager.Instance.hasSpoon = false;
        NotificationManager.Instance.showNotification("Spoon has been removed from your inventory", NotificationPanelColor.INFO);
    }

    public void GiveSpoon()
    {
        PickUpSystem.instance.inventoryData.AddItem(PickUpSystem.instance.spoon);
        DialogueManager.Instance.hasIron = true;
        NotificationManager.Instance.showNotification("Spoon has been added to your inventory", NotificationPanelColor.INFO);
    }

    public void GiveIron()
    {
        PickUpSystem.instance.inventoryData.AddItem(PickUpSystem.instance.iron);
        DialogueManager.Instance.hasSpoon = true;
        NotificationManager.Instance.showNotification("Iron has been added to your inventory", NotificationPanelColor.INFO);
    }

    public void GotPasswordFromFatima(){
        DialogueManager.Instance.GotPasswordFromFatima = true;
    }
}
