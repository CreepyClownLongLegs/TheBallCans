using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IDataPersistence
{

    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    private SpriteRenderer visual;
    private ParticleSystem collectParticle;
    private bool collected = false;

    private void Awake() 
    {
        visual = this.GetComponentInChildren<SpriteRenderer>();
        collectParticle = this.GetComponentInChildren<ParticleSystem>();
        collectParticle.Stop();
    }

    public void LoadGame(GameData data)
    {
        data.coinsCollected.TryGetValue(id, out collected);
        if (collected)
        {
            visual.gameObject.SetActive(false);
        }
    }

    public void SaveGame(GameData data)
    {
        if (data.coinsCollected.ContainsKey(id))
        {
            data.coinsCollected.Remove(id);
        }
        data.coinsCollected.Add(id, collected);
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
