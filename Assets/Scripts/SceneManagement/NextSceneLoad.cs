using System.Collections;
using System.Collections.Generic;
using Systems.SceneManagement;
using Unity.VisualScripting;
using UnityEngine;

public class NextSceneLoad : MonoBehaviour
{

[SerializeField] int  nextSceneToLoad;
[SerializeField] Vector2 position;
private void OnTriggerEnter2D(Collider2D collider2D){
    if(collider2D.gameObject.CompareTag("Player")){
            _ = SceneLoader.Instance.LoadSceneGroup(nextSceneToLoad);
         GameObject.FindGameObjectWithTag("Player").transform.position = this.position;
    }
}

}
