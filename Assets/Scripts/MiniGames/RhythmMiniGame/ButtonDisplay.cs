using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ButtonDisplay : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject perfectEffect;
    [SerializeField] private GameObject missEffect;
    public ButtonArrowType arrowType;
    public ArrowType arrowTag;
    private Image sr;
    private Collider2D Collider2D;
    public int missScoreMinusPoints = 5;
    public int hitScorePlusPoints = 10;
    private Animator animator;
    private Coroutine showHitEffect;
    // Start is called before the first frame update

    void Awake(){
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        sr = GetComponentInChildren<Image>();
        if(arrowType == ButtonArrowType.LEFT){
            InputSystem.leftArrowClicked += ButtonCanceled;
            InputSystem.leftArrowCanceled += ButtonClicked;

        }
        if(arrowType == ButtonArrowType.RIGHT){
            InputSystem.rightArrowClicked += ButtonCanceled;
            InputSystem.rightArrowCanceled += ButtonClicked;

        }
        if(arrowType == ButtonArrowType.UP){
            InputSystem.upArrowClicked += ButtonCanceled;
            InputSystem.upArrowCanceled += ButtonClicked;

        }
        if(arrowType == ButtonArrowType.DOWN){
            InputSystem.downArrowClicked += ButtonCanceled;
            InputSystem.downArrowCanceled += ButtonClicked;

        }
        animator.Play("leftArrow");
    }

    private void ButtonClicked(){
        this.sr.color = new Color(0.5f,0.5f,0.5f,1f);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.kick, this.transform.position);
        animator.Play("leftArrow");
        if(Collider2D!=null){
            if(RhythmGameManager.Instance.currentMultiplierts > 2){
                showEffectText(perfectEffect);
            }else{
                showEffectText(hitEffect);
            }
            Destroy(Collider2D.gameObject);
            AddPointsToScore();
            Debug.Log("Note hit");
        }
    }

    private void AddPointsToScore(){
        RhythmGameManager.Instance.AddToScore(hitScorePlusPoints);
        RhythmGameManager.Instance.AddToMultipliers();
        updateScoreText();
    }

    private void SubstractPointsFromScore(){
        RhythmGameManager.Instance.score -= missScoreMinusPoints;
    }

    private void ButtonCanceled(){
        this.sr.color = new Color(1f,1f,1f,1f);
    }

    void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.CompareTag(arrowTag.ToString())){
            this.Collider2D = collider2D;
        }
    }

    void OnTriggerExit2D(Collider2D collider2D){
        if(collider2D.gameObject.CompareTag(arrowTag.ToString())){
            this.Collider2D = null;
        }
    }

    void updateScoreText(){
        RhythmGameManager.Instance.scoreText.text = "Score : " + RhythmGameManager.Instance.score;
    }

    private void showEffectText(GameObject hitEffect){
        GameObject effect = Instantiate(hitEffect, this.transform);
        effect.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 10f, 0f);
    }

    private void OnDestroy(){
            InputSystem.leftArrowClicked -= ButtonCanceled;
            InputSystem.leftArrowCanceled -= ButtonClicked;

            InputSystem.rightArrowClicked -= ButtonCanceled;
            InputSystem.rightArrowCanceled -= ButtonClicked;

            InputSystem.upArrowClicked -= ButtonCanceled;
            InputSystem.upArrowCanceled -= ButtonClicked;


            InputSystem.downArrowClicked -= ButtonCanceled;
            InputSystem.downArrowCanceled -= ButtonClicked;
    }


}

public enum ButtonArrowType{
    LEFT,
    RIGHT,
    UP,
    DOWN
}

public enum ArrowType{
    leftArrow,
    rightArrow,
    upArrow,
    downArrow
}
