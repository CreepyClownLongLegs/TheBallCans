using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedNotes : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider2D){
        AudioManager.instance.PlayOneShot(FMODEvents.instance.snare, this.transform.position);
        if(collider2D.gameObject.CompareTag("leftArrow")){
            showEffectText(550f);
            Debug.Log("Missed note");
        }
        if(collider2D.gameObject.CompareTag("downArrow")){
            showEffectText(800f);
        }
        if(collider2D.gameObject.CompareTag("upArrow")){
            showEffectText(1100f);
        }
        if(collider2D.gameObject.CompareTag("rightArrow")){
            showEffectText(1350f);
        }
        Destroy(collider2D.gameObject);
        SubstractPointsFromScore();
        RhythmGameManager.Instance.resetMultiplier();
    }

    private void SubstractPointsFromScore(){
        RhythmGameManager.Instance.score -= 8;
        updateScoreText();
    }

    void updateScoreText(){
        RhythmGameManager.Instance.scoreText.text = "Score : " + RhythmGameManager.Instance.score;
    }

    private void showEffectText(float xOffset){
        GameObject effect = Instantiate(hitEffect, this.transform);
        effect.transform.position = new Vector3(xOffset, hitEffect.transform.position.y + 100f, 0f);
    }

}
