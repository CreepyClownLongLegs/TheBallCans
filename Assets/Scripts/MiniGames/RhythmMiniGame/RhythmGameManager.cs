using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Cysharp.Threading.Tasks.Triggers;
using FMOD.Studio;
using Systems.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class RhythmGameManager : MonoBehaviour
{
    public float gameToStart = 10f;
    private CharacterController2D playerController;
    private SpriteRenderer playerRenderer;
    public bool scrollerScrolling = false;
    private int expirience = 0;
    public static RhythmGameManager Instance {get; private set;}
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI multipliersText;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject countDown;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject door; 
    private EventInstance Suada;
    public int score = 0;
    public int currentMultiplierts = 0;

    void Awake(){
        if(Instance != null){
            Destroy(Instance);
        }
        Instance = this;

        AudioManager.instance.StopSong(AudioManager.instance.musicEventInstance);
        Suada = AudioManager.instance.InitializeSuada();
    }
    void Start()
    {
        door.SetActive(false);
        startPanel.SetActive(true);
        countDown.SetActive(false);
        endPanel.SetActive(false);
        StartScrolling();
        Suada.start();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        playerRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        playerController.elevatorPanelIsOpen = true;
        playerRenderer.enabled = false;
        multipliersText.gameObject.SetActive(false);
        scoreText.text = "Score : " + score;
        updateMultipliersText();
    }

    public void EndGame(){
        endPanel.SetActive(true);
        addExpirience();
        setEndPanelText(endPanel.GetComponentInChildren<TextMeshProUGUI>());
        InputSystem.interactPressed += LoadRoom;
    }

    private void LoadRoom(){
        Suada.stop(STOP_MODE.IMMEDIATE);
        playerRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        playerController.elevatorPanelIsOpen = false;
        playerRenderer.enabled = true;
        GameEventsManager.instance.playerEvents.RhytmGamePlayed();
        EpisodeManager.instance.EpisodeOneRhytmGameFinished = true;
        InputSystem.interactPressed -= LoadRoom;
        this.door.SetActive(true);
    }

    public void addExpirience(){
        expirience = (int)Math.Sqrt(score);
        GameEventsManager.instance.playerEvents.ExperienceGained(expirience);
    }

    public void setEndPanelText(TextMeshProUGUI endText){
        string JuryCommentar = "";
        if(score <= 300){
            JuryCommentar = "We've seen worse :)";
        } 
        if(score>300 && score <= 600){
            JuryCommentar = "Heyy....this guys pretty good....";
        }
        if(score > 600){
            JuryCommentar = "Please move to Serbia";
        }
        string text = "Score : " +score +"<br>Experience Gained : "+ expirience+"EXP<br>Jury Commentery : "+ JuryCommentar + "<br>Click 'E' to exit!";
        endText.text = text;
    }


    public void AddToMultipliers(){
        currentMultiplierts ++;
        updateMultipliersText();
    }

    public void updateMultipliersText(){
        multipliersText.text = "Combo X" + currentMultiplierts;
    }

    private void StartScrolling(){
        StartCoroutine(startScrolling());
    }

    private IEnumerator startScrolling(){
        yield return new WaitForSeconds(gameToStart);
        startPanel.SetActive(false);
        countDown.SetActive(true);
        scrollerScrolling = true;
    }

    public void AddToScore(int addToScore){
        if(currentMultiplierts >= 2){
            this.score += (addToScore*currentMultiplierts/(currentMultiplierts-1)) + addToScore;
            multipliersText.gameObject.SetActive(true);
            updateMultipliersText();
        }else {
            this.score += addToScore;
        }
    }

    public void resetMultiplier(){
        this.currentMultiplierts = 0;
        updateMultipliersText();
        multipliersText.gameObject.SetActive(false);
    }

}
