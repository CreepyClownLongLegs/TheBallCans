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
    int lifePoints;
    // Start is called before the first frame update
    void Start()
    {
        lifePoints = 2;
        rb = GetComponentInChildren<Rigidbody2D>();
        randomXSpeed = Random.Range(speedXmin, speedXmax);
        StartCoroutine(die(lifeSpanInSeconds));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    void move(){
        rb.velocity = new Vector2( randomXSpeed, speedY);
    }

    private IEnumerator die(float seconds){
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.CompareTag("Player")){
            KayakingGameManager.Instance.DamageTaken();
            Destroy(this.gameObject);
        }
        if(collider2D.gameObject.CompareTag("Bullet")){
            this.lifePoints --;
            this.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.kick, this.transform.position);
            if(lifePoints == 0){
                this.GetComponent<ParticleSystem>().Play();
                this.GetComponentInChildren<SpriteRenderer>().enabled = false;
                this.GetComponent<CircleCollider2D>().enabled = false;
                ExpirienceManager.Instance.addExpirience(3);
                StartCoroutine(die(0.4f));
            }
        }
    }
}
