using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedNotes : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider2D){
        Destroy(collider2D.gameObject);
        SubstractPointsFromScore();
        RhythmGameManager.Instance.resetMultiplier();
        Debug.Log("Missed note");
    }

    private void SubstractPointsFromScore(){
        RhythmGameManager.Instance.score -= 8;
        updateScoreText();
    }

    void updateScoreText(){
        RhythmGameManager.Instance.scoreText.text = "Score : " + RhythmGameManager.Instance.score;
    }
}
