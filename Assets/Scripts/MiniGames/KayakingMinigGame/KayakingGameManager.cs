using System;
using System.Collections;
using System.Collections.Generic;
using Systems.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class KayakingGameManager : MonoBehaviour
{

[SerializeField] public float cameraOffsetX;
[SerializeField] float speedXAddOn;
[SerializeField] GameObject[] oldHearts;
[SerializeField] public TextMeshProUGUI scoreText;
[SerializeField] public GameObject gameOverPanel;
[SerializeField] public GameObject gameStartPanel;
[SerializeField] public TextMeshProUGUI GameOverScoreText;
[SerializeField] public GameObject door;
public CameraController camera;
private Vector2 playerInitialPosition;
private CharacterController2D characterController2D;
public int score = 0;
private bool gameIsOver = false;
private bool gameHasBeenStarted = false;
private GameObject[] hearts;
public int memory = 0;
public static event Action GameOver;
public static event Action GameStart;
public static event Action MemoryCollectedAction;

public static KayakingGameManager Instance { get; private set; }

    void Awake(){

        Instance = this; 
        DialogueManager.Instance.EpisodeOneKayakingGameFinished = false;
        StartCoroutine(DialogueManager.Instance.ExitDialogueMode());
    } 
    
    void Start()
    {
        this.door.SetActive(false);
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        camera.offsetX = cameraOffsetX;
        characterController2D = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        gameOverPanel.SetActive(false);
        gameStartPanel.SetActive(true);
        if(EpisodeManager.instance.secondEpisode){
            GameObject.FindGameObjectWithTag("Gun").SetActive(true);
            gameStartPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Same as BEfore <br> Except you got a gun now :3 <br> use it by pressing the Space bar";
        }else {
            GameObject.FindGameObjectWithTag("Gun").SetActive(false);
        }
        InputSystem.interactPressed += ReturnToRoom;
        InputSystem.interactPressed += StartGame;
        this.hearts = oldHearts;
    }

    public void MemoryCollected(){
        memory++;
        MemoryCollectedAction?.Invoke();
        if(memory == 1){
            NotificationManager.Instance.showNotification("Fatima : AH I THINK IM STARTING TO R3M3MB3R !1!!1", NotificationPanelColor.INFO);
        } if (memory == 2){
            NotificationManager.Instance.showNotification("Fatima : Was it Cazin...no no , Mostar ??", NotificationPanelColor.INFO);
        }
        if(memory >= 3){
            DialogueManager.Instance.EpisodeOneKayakingGameFinished = true;
            NotificationManager.Instance.showNotification("Fatima : I GOT IT !1!!1", NotificationPanelColor.SUCCSES);
            GameOverCalled();
        }
    }

    public void DamageTaken(){
        AudioManager.instance.PlayOneShot(FMODEvents.instance.ouch, this.transform.position);
        if(hearts.Length == 0){
            //died
            GameOverCalled();
            return;
        }
        makeNewListwithOneLessGameObject();
    }

    public void GameOverCalled(){
            camera.offsetX = 0;
            this.characterController2D.speedX_addOn = 0f;
            GameOver?.Invoke();
            SetGameOverPanel();
            gameIsOver = true;
    }

    private void makeNewListwithOneLessGameObject(){
        hearts[hearts.Length-1].SetActive(false);
        GameObject[] newList = new GameObject[hearts.Length-1];
        for(int i=0; i<newList.Length; i++){
            newList[i] = hearts[i];
        }
        this.hearts = newList;
    }

    private void SetGameOverPanel(){
        string text = "Your final score is: " + score + "<br> You've collected " + memory +  " memories <br> Press 'E' to return";
        this.GameOverScoreText.text = text;
        this.gameOverPanel.SetActive(true);
    }

    private void ReturnToRoom(){
        if(gameIsOver){
            this.gameIsOver = false;
            this.gameOverPanel.SetActive(false);
            InputSystem.interactPressed -= ReturnToRoom;
            this.door.SetActive(true);}
    }

    private void StartGame(){
        if(!gameHasBeenStarted){
            gameHasBeenStarted = true;
            gameStartPanel.SetActive(false);
            this.characterController2D.speedX_addOn = speedXAddOn;
            InputSystem.interactPressed -= StartGame;
            GameStart?.Invoke();
        }
    }

}
