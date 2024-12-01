using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 maxX = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        Debug.Log("Maximum x value on screen : " + maxX.x);
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = transform.position;
        position = new Vector3(position.x + Time.unscaledDeltaTime * speed, position.y, 0f);
        transform.position = position;
        Vector2 maxX = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        if(transform.position.x > (Math.Abs(maxX.x) + 8f)){
            Destroy(this.gameObject);
        }
    }
}
