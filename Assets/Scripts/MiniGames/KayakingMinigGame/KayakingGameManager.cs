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
public static event Action GameOver;
public static event Action GameStart;
public int score = 0;
private bool gameIsOver = false;
private bool gameHasBeenStarted = false;
private GameObject[] hearts;

public static KayakingGameManager Instance { get; private set; }

    void Awake(){
            if (Instance != null && Instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        Instance = this; 
    } 
    }
    void Start()
    {
        this.door.SetActive(false);
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        camera.offsetX = cameraOffsetX;
        characterController2D = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        gameOverPanel.SetActive(false);
        gameStartPanel.SetActive(true);
        InputSystem.interactPressed += ReturnToRoom;
        InputSystem.interactPressed += StartGame;
        this.hearts = oldHearts;
    }

    public void DamageTaken(){
        if(hearts.Length == 0){
            //died
            camera.offsetX = 0;
            this.characterController2D.speedX_addOn = 0f;
            GameOver?.Invoke();
            SetGameOverPanel();
            gameIsOver = true;
            return;
        }
        makeNewListwithOneLessGameObject();
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
        string text = "Your final score is: " + score + "<br> You've collected 0 memories <br> Press 'E' to return";
        this.GameOverScoreText.text = text;
        this.gameOverPanel.SetActive(true);
    }

    private void ReturnToRoom(){
        if(gameIsOver){
            this.gameIsOver = false;
            this.gameOverPanel.SetActive(false);
            InputSystem.interactPressed -= ReturnToRoom;
            Destroy(this);
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
