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
private void Awake(){
    visualCue.SetActive(false);
}

private void OnEnable(){
    InputSystem.interactPressed += noTalking;
}

private void OnDestroy(){
    InputSystem.interactPressed -= noTalking;
}

private void OnTriggerEnter2D(Collider2D collider2D){
    if(collider2D.gameObject.CompareTag("Player")) {
        visualCue.SetActive(true);}
}

private void OnTriggerExit2D(Collider2D collider2D){
    if(collider2D.gameObject.CompareTag("Player")) 
        visualCue.SetActive(false);
        playerInRangeOnce = false;
}

private void noTalking(){
    visualCue.SetActive(false);
}

private void FixedUpdate(){
    if(!DialogueManager.Instance.dialogueIsPlaying && InputSystem.Instance.GetInteractPressed() && !playerInRangeOnce) {
        playerInRangeOnce = true;
        DialogueManager.Instance.EnterDialogueMode(inkJSON);
    }
}

}
