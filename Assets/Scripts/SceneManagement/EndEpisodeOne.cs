using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEpisodeOne : MonoBehaviour
{
    [SerializeField]
    private GameObject endOfEpisodeOnePanel;
    private BoxCollider2D boxCollider2D;

    void Start()
    {   
        endOfEpisodeOnePanel.SetActive(false);
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = EpisodeManager.instance.EpisodeOneRhytmGameFinished;
    }

    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.CompareTag("Player")){
            endOfEpisodeOnePanel.SetActive(true);
            EpisodeManager.instance.firstEpisode = false;
            EpisodeManager.instance.secondEpisode = true;
        }
    }
}
