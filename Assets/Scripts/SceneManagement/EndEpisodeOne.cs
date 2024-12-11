using System.Collections;
using TMPro;
using UnityEngine;

public class EndEpisodeOne : MonoBehaviour
{
    [SerializeField]
    private GameObject endOfEpisodeOnePanel;
    private BoxCollider2D boxCollider2D;
    private TextMeshProUGUI text;
    string sleepingText = "zzZZzzZZ <br> zzZZZZzz";
    string EpisodeTwoText = "Begin Of Episode Two: <br> You ain't so bad kid";
    public float sleepingTimer = 30f;
    public float fadeInOutTime = 50f;
    Color black = Color.black;


    void Start()
    {   
        endOfEpisodeOnePanel.SetActive(false);
    }

    void OnEnabled(){

    }

    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.CompareTag("Player") && EpisodeManager.instance.EpisodeOneRhytmGameFinished && !EpisodeManager.instance.secondEpisode){
            endOfEpisodeOnePanel.SetActive(true);
            StartCoroutine(playSleepingSound());
            EpisodeManager.instance.firstEpisode = false;
            EpisodeManager.instance.secondEpisode = true;
            EpisodeManager.instance.ChangeDoorValue("Romania", true);
            EpisodeManager.instance.saveNPCShowVariable("ZlatanNPCLobby",true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>().elevatorPanelIsOpen = true;
            boxCollider2D = GetComponent<BoxCollider2D>();
            EpisodeManager.instance.GoToSleepPanel.SetActive(false);
            boxCollider2D.enabled = false;
            //endOfEpisodeOnePanel.GetComponent<EndOfEPisodeOnePanel>().FadeInOut();
        }
    }


    private IEnumerator playSleepingSound(){
        yield return new WaitForSeconds(6f);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.sleepingSFX, this.transform.position);
    }


}
