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
            _ = SceneLoader.Instance.LoadSceneGroup(nextSceneToLoad);
         GameObject.FindGameObjectWithTag("Player").transform.position = this.position;
    }
}

}
