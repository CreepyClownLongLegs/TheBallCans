using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Cysharp.Threading.Tasks.Triggers;
using FMOD.Studio;
using TMPro;
using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    public float gameToStart = 10f;
    private CharacterController2D playerController;
    private SpriteRenderer playerRenderer;
    public bool scrollerScrolling = false;
    public static RhythmGameManager Instance {get; private set;}
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI multipliersText;
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

    public void OnDestroy(){
        Suada.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
