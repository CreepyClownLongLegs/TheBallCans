using System.Collections;
using System.Collections.Generic;
using Systems.SceneManagement;
using Unity.VisualScripting;
using UnityEngine;

public class NextSceneLoad : MonoBehaviour
{

[SerializeField] int  nextSceneToLoad;
[SerializeField] Vector2 position;
private Collider2D collider2D;
private EpisodeManager episodeManager;
public string ID = "";

private void Start(){
    ID = this.name;
    episodeManager = EpisodeManager.instance;
}
private void OnTriggerEnter2D(Collider2D collider2D){
    if(episodeManager.DoorExistsInDictionary(ID)){
        if(!episodeManager.GetDoorValue(ID)){
            return;
        }
    }
    if(collider2D.gameObject.CompareTag("Player")){
        //TODO: find actual media sources
        if(ID == "Serbia" && !EpisodeManager.instance.FirstTimeInSerbiaRoom){
            EpisodeManager.instance.FirstTimeInSerbiaRoom = true;
            NewsLogScrollingList.instance.CreateNewsWithoutVideo("Serbians at it again", "3 Austrians killed by a gang of serbians", "trustmebro.com");;
        }
        if(ID == "Romania" && !EpisodeManager.instance.FirstTimeInRomaniaRoom){
            EpisodeManager.instance.FirstTimeInRomaniaRoom = true;
            NewsLogScrollingList.instance.CreateNewsWithoutVideo("Romanian gang caught after 27 burglaries", "Niederösterreich 09.10.2019 14:03", "Kronen Zeitung");
        }
        if(ID == "Bosnia" && !EpisodeManager.instance.FirstTimeInBosniaRoom){
            EpisodeManager.instance.FirstTimeInBosniaRoom = true;
            NewsLogScrollingList.instance.CreateNewsWithoutVideo("Fight against Srebrenica denial continues", "24. Mai 2024, 17:10", "Der Standard");
        }
            _ = SceneLoader.Instance.LoadSceneGroup(nextSceneToLoad);
         GameObject.FindGameObjectWithTag("Player").transform.position = this.position;
    }
}

}
