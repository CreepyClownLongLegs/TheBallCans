using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrugger : MonoBehaviour
{
[Header("Trigger Bounds")]
private Image ContactIconImage;
[SerializeField]private GameObject visualCue;
[SerializeField]private TextAsset inkJSON;
[SerializeField]public GameObject ContactIcon; 
[SerializeField]public String contactName = "";
private bool playerInRangeOnce;
private bool playerCloseEnough;
private void Awake(){
    visualCue.SetActive(false);
}

private void Start(){
    ContactIconImage = ContactIcon.GetComponent<Image>();
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
        //add to contacts
        ContactsScrollingList.instance.CreateContact(ContactIconImage, contactName);
        //to make sure for before opening the contacts te first time
    }
}

private void FixedUpdate(){

}

}
