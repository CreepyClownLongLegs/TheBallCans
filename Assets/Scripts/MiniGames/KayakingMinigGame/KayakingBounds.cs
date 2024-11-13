using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KayakingBounds : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.CompareTag("Player")){
            KayakingGameManager.Instance.camera.updateCamera = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D){
        if(collider2D.gameObject.CompareTag("Player")){
            KayakingGameManager.Instance.camera.updateCamera = true;
        }
    }
}
