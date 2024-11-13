using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speedXmin;
    [SerializeField] float speedXmax;
    [SerializeField] float speedY;
    [SerializeField] float lifeSpanInSeconds = 5f;
    private float randomXSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        randomXSpeed = Random.Range(speedXmin, speedXmax);
        StartCoroutine(die());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    void move(){
        rb.velocity = new Vector2( randomXSpeed, speedY);
    }

    private IEnumerator die(){
        yield return new WaitForSeconds(lifeSpanInSeconds);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.CompareTag("Player")){
            KayakingGameManager.Instance.DamageTaken();
            Destroy(this.gameObject);
        }
    }
}
