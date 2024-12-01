using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Memory : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speedXmin;
    [SerializeField] float speedXmax;
    [SerializeField] float speedY;
    [SerializeField] float lifeSpanInSeconds = 6f;
    private float randomXSpeed;

    private SpriteRenderer spriteRendere;
    private bool collected = false;
    ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        spriteRendere = GetComponentInChildren<SpriteRenderer>();
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
        if(collider2D.gameObject.CompareTag("Player") && !this.collected){
            this.collected = true;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.itemCollected, this.transform.position);
            KayakingGameManager.Instance.MemoryCollected();
            StartCoroutine(particleCoroutine());
        }
    }

    private IEnumerator particleCoroutine(){
        spriteRendere.enabled = false;
        particleSystem.Play();
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
