using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
        this.transform.position = new Vector3(transform.position.x - KayakingGameManager.Instance.cameraOffsetX,
                                                transform.position.y, 0f);
        player = GameObject.FindGameObjectWithTag("MainCamera");
        this.transform.SetParent(player.transform);
    }

}
