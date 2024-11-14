using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IDataPersistence
{

    [SerializeField] private string id;
    private SpriteRenderer visual;
    private ParticleSystem collectParticle;
    private bool collected = false;

    private CircleCollider2D collider2D;

    private void Awake() 
    {
        visual = this.GetComponentInChildren<SpriteRenderer>();
        collectParticle = this.GetComponentInChildren<ParticleSystem>();
        collider2D = this.GetComponentInChildren<CircleCollider2D>();
        collectParticle.Stop();
        id = this.name;
        StartCoroutine(callLoadData());
    }

    public void LoadGame(GameData data)
    {
        data.coinsCollected.TryGetValue(id, out collected);
        Debug.Log("Searching For Coin");
        if (collected)
        {
            Debug.Log("Coin with value " + id + "has been found");
            DisableCoin();
        }
    }

    public void SaveGame(GameData data)
    {
        data.coinsCollected.TryGetValue(id, out collected);
        if(!collected){
            data.coinsCollected.Add(id, true);
        }
        Debug.Log("saving coins");
    }

    private void Start()
    {
        //emitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.coinIdle, this.gameObject);
        //emitter.Play();
        LoadGame(DataPersistenceManager.instance.GetGameData());

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
        //AudioManager.instance.PlayOneShot(FMODEvents.instance.itemCollected, this.transform.position);
        SaveGame(DataPersistenceManager.instance.GetGameData());
        DataPersistenceManager.instance.SaveGame();
        GameEventsManager.instance.miscEvents.CoinCollected();
        DisableCoin();
    }

    private void DisableCoin(){
        visual.enabled = false;
        collider2D.enabled = false;
    }

    private IEnumerator callLoadData(){
        yield return new WaitForSeconds(0.1f);
        LoadGame(DataPersistenceManager.instance.GetGameData());
    }
}
