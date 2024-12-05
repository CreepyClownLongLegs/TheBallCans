using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EpisodeGameObjetc : MonoBehaviour
{
    void Start(){
        if(EpisodeManager.instance.secondEpisode){
            this.transform.GetChild(0).gameObject.SetActive(true);
        }else{
            this.transform.GetChild(0).gameObject.SetActive(false);            
        }
    }
}
