using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDialogueTrigger : MonoBehaviour
{
[Header("Trigger Bounds")]
[SerializeField]private TextAsset inkJSON;

private bool playerInRangeOnce;
private void Awake(){
}

private void OnTriggerEnter2D(Collider2D collider2D){
}

private void OnTriggerExit2D(Collider2D collider2D){
    if(collider2D.gameObject.CompareTag("Player")) 
        playerInRangeOnce = false;
}


private void FixedUpdate(){
    if(!DialogueManager.Instance.dialogueIsPlaying && Input.GetKeyDown(KeyCode.E) && !playerInRangeOnce) {
        playerInRangeOnce = true;
        DialogueManager.Instance.EnterDialogueMode(inkJSON);
    }
}
}
