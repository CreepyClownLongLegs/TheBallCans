using System;
using Ink.Runtime;
using Systems.SceneManagement;
using UnityEngine;

public class InkExternalFunctions
{
    bool already_sent_kayaking_video = false;
    bool already_sent_spotlight_video = false;
    bool already_sent_pljeskavica_video = false;
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
        story.BindExternalFunction("takeMixer", TakeMixer);
        story.BindExternalFunction("takeSlingshot", TakeSlingshot);
        story.BindExternalFunction("giveSlingshot", GiveSlingshot);
        story.BindExternalFunction("giveGun", GiveGun);
        story.BindExternalFunction("startRhytmGame", StartRhythmGame);
        story.BindExternalFunction("kayakingVideo", KayakingNews);
        story.BindExternalFunction("spotlightVideo", SpotLightNews);
        story.BindExternalFunction("pljeskavicaVideo", PljeskavicaNews);
        story.BindExternalFunction("isInContacts", (string charaName) => {return EpisodeManager.instance.contacts.ContainsKey(charaName);}, false);
        story.BindExternalFunction("endGame", endGame);
    }


    public void Unbind(Story story) 
    {
        story.UnbindExternalFunction("startEpisodeOneKayakingGame");
        story.UnbindExternalFunction("startEpisodeOneCookingGame");
        story.UnbindExternalFunction("GotPasswordFromFatima");
        story.UnbindExternalFunction("UnlockSerbiaRoom");
        story.UnbindExternalFunction("takeIron");
        story.UnbindExternalFunction("takeSpoon");
        story.UnbindExternalFunction("giveMixer");
        story.UnbindExternalFunction("giveSpoon");
        story.UnbindExternalFunction("giveIron");
        story.UnbindExternalFunction("takeMixer");
        story.UnbindExternalFunction("takeSlingshot");
        story.UnbindExternalFunction("giveSlingshot");
        story.UnbindExternalFunction("giveGun");
        story.UnbindExternalFunction("startRhytmGame");
        story.UnbindExternalFunction("kayakingVideo");
        story.UnbindExternalFunction("spotlightVideo");
        story.UnbindExternalFunction("pljeskavicaVideo");
        story.UnbindExternalFunction("isInContacts");
        story.UnbindExternalFunction("endGame");
    }

    public void StartEpisodeOneKayakingGame(){
        Debug.Log("Starting Kayaking Game");
        _ = SceneLoader.Instance.LoadSceneGroup(6);
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0,0,0);
    }

    public void StartRhythmGame(){
        Debug.Log("Starting Rhythm Game");
        _ = SceneLoader.Instance.LoadSceneGroup(8);
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0,0,0);
    }

    public void UnlockSerbiaRoom(){
        EpisodeManager.instance.ChangeDoorValue("Serbia", true);
        EpisodeManager.instance.saveNPCShowVariable("RomaniaNPCKitchen", false);
        EpisodeManager.instance.saveNPCShowVariable("ZoranNPCKitchen", false);
        EpisodeManager.instance.saveNPCShowVariable("RomaniaNPCRoom", true);
        NotificationManager.Instance.showNotification("You've unlocked Zlatans Room!", NotificationPanelColor.SUCCSES);
    }

    //its actually now used for nboth episodes haha...
    public void StartEpisodeOneCookingGame(){
        Debug.Log("Starting Cooking Game");
        _ = SceneLoader.Instance.LoadSceneGroup(7);
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(14,-8,0);
    }

    public void KayakingNews(){
        if(!already_sent_kayaking_video){
        NewsLogScrollingList.instance.CreateNewsWithVideo("Tourists from everywhere coming to Neretva Rafting", "03.08.2024, 23:45 BiH", "Vijesti.ba", VideoFiles.instance.kayakingVideo, FMODEvents.instance.kayakingVideo);
        EpisodeManager.instance.GoToSleepPanel.SetActive(true);
        already_sent_kayaking_video = true;    
        }
    }

    public void endGame(){
        GameObject.FindGameObjectWithTag("TheEnd").transform.GetChild(0).gameObject.SetActive(true);
    }

    public void SpotLightNews(){
        if(!already_sent_spotlight_video){
        already_sent_spotlight_video = true;
        NewsLogScrollingList.instance.CreateNewsWithVideo("Bucharest’s Spotlight festival returns to Calea Victoriei", "27 September 2024, Romania", "www.romania-insider.com", VideoFiles.instance.spotLightVideo, FMODEvents.instance.spotLightVideo);
        }
    }

    public void PljeskavicaNews()
    {
        if (!already_sent_pljeskavica_video)
        {
            NewsLogScrollingList.instance.CreateNewsWithVideo("Leskovac makes world's biggest pljeskavica, again!", "30.08.2024", "www.ktv.rs", VideoFiles.instance.pljeskavicaVideo, FMODEvents.instance.pljeskavicaVideo);
            already_sent_pljeskavica_video = true;
        }
    }


    public void GiveMixer()
    {
        PickUpSystem.instance.inventoryData.AddItem(PickUpSystem.instance.mixer);
        EpisodeManager.instance.gotMixer = true;
        NotificationManager.Instance.showNotification("Mixer has been added to your inventory", NotificationPanelColor.INFO);
    }

    public void TakeIron()
    {
        PickUpSystem.instance.inventoryData.RemoveItemWithName("Iron");
        DialogueManager.Instance.hasIron = false;
        GameEventsManager.instance.goldEvents.MoneySpent(10);
        NotificationManager.Instance.showNotification("Iron and Soon have been removed from your inventory", NotificationPanelColor.INFO);
    }

    public void TakeSpoon()
    {
        PickUpSystem.instance.inventoryData.RemoveItemWithName("Spoon");
        DialogueManager.Instance.hasSpoon = false;
        NotificationManager.Instance.showNotification("10 Dabloons have been taken", NotificationPanelColor.INFO);
    }

    public void TakeMixer(){
        PickUpSystem.instance.inventoryData.RemoveItemWithName("Mixer");
        NotificationManager.Instance.showNotification("Mixer has been taken", NotificationPanelColor.INFO);      
    }

    public void TakeSlingshot(){
        PickUpSystem.instance.inventoryData.RemoveItemWithName("Slingshot");
        NotificationManager.Instance.showNotification("Slingshot has been taken", NotificationPanelColor.INFO);      
    }

    public void GiveSlingshot()
    {
        PickUpSystem.instance.inventoryData.AddItem(PickUpSystem.instance.slingshot);
        EpisodeManager.instance.gotSlingshot = true;
        NotificationManager.Instance.showNotification("Slingshot has been added to your inventory", NotificationPanelColor.INFO);
    }
    public void GiveGun()
    {
        PickUpSystem.instance.inventoryData.AddItem(PickUpSystem.instance.laserGun);
        NotificationManager.Instance.showNotification("Laser Gun has been added to your inventory", NotificationPanelColor.INFO);
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
