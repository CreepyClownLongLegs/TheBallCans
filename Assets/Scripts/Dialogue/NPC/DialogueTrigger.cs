using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrugger : MonoBehaviour
{
[Header("Trigger Bounds")]
[SerializeField]private GameObject visualCue;
[SerializeField]private TextAsset inkJSON;

private bool playerInRangeOnce;
private bool playerCloseEnough;
private void Awake(){
    visualCue.SetActive(false);
}

private void Start(){
    playerCloseEnough = false;
    playerInRangeOnce = false;
}

private void OnEnable(){
    InputSystem.interactPressed += noTalking;
}

private void OnDestroy(){
    InputSystem.interactPressed -= noTalking;
}

private void OnTriggerEnter2D(Collider2D collider2D){
    if(collider2D.gameObject.CompareTag("Player")) {
        visualCue.SetActive(true);
        playerCloseEnough = true;
        }
}

private void OnTriggerExit2D(Collider2D collider2D){
    if(collider2D.gameObject.CompareTag("Player")) 
        visualCue.SetActive(false);
        playerInRangeOnce = false;
        playerCloseEnough = false;
}

private void noTalking(){
    visualCue.SetActive(false);
    if(!DialogueManager.Instance.dialogueIsPlaying && playerCloseEnough) {
        playerInRangeOnce = true;
        DialogueManager.Instance.EnterDialogueMode(inkJSON);
    }
}

private void FixedUpdate(){

}

}
