using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    private float timer = 4f;
    public float incrementTimer = 0.1f;
    private TextMeshProUGUI countDownText;
    // Start is called before the first frame update
    void Start()
    {
        countDownText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer > 1f){
            countDownText.text = "" + Mathf.RoundToInt(timer);
        }
        if(timer >0f && timer < 1f){
            countDownText.text = "GO!";
        } 
        if(timer <= 0f){
            Destroy(this.gameObject);
        }
        timer -= incrementTimer;
    }
}
