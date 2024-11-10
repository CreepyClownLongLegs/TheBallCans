using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private SpriteRenderer visual;
    private ParticleSystem collectParticle;
    private bool collected = false;

    private void Awake() 
    {
        visual = this.GetComponentInChildren<SpriteRenderer>();
        collectParticle = this.GetComponentInChildren<ParticleSystem>();
        collectParticle.Stop();
    }

    private void Start()
    {
        //emitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.coinIdle, this.gameObject);
        //emitter.Play();

    }

    private void OnTriggerEnter2D() 
    {
        if (!collected) 
        {
            collectParticle.Play();
            CollectCoin();
        }
    }

    private void CollectCoin() 
    {
        collected = true;
        visual.gameObject.SetActive(false);
        //AudioManager.instance.PlayOneShot(FMODEvents.instance.itemCollected, this.transform.position);

        if(collected){
            GameEventsManager.instance.miscEvents.CoinCollected();
            Destroy(this.gameObject);
        }
    }

}
