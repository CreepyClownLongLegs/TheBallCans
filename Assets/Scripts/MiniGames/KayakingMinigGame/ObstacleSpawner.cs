using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    
    public float minY;
    public float maxY;
    public float valueX;
    public float minSpawningTime = 0.5f;
    public float maxSpawningTime = 0.8f;
    private float randomSpawningTime;
    public float timer = 0f;
    private bool spawn = false;

    // Update is called once per frame
    void Start(){
        KayakingGameManager.GameOver += dontSpawn;
        KayakingGameManager.GameStart += startToSpawn;
    }

    private void OnDestroy(){
        KayakingGameManager.GameOver -= dontSpawn;
        KayakingGameManager.GameStart -= startToSpawn;
    }

    void FixedUpdate()
    {
        if(timer > randomSpawningTime && spawn){
            Spawn();
            Spawn();
            timer = 0f;
            int score = KayakingGameManager.Instance.score ++;
            KayakingGameManager.Instance.scoreText.text = "Score : " + score; 
        }
        timer += 0.01f;
    }

    private void dontSpawn(){
        this.spawn = false;
    }

    private void startToSpawn(){
        this.spawn = true;
    }

    private void Spawn(){
        float randomY = Random.Range(minY, maxY);
        this.randomSpawningTime = Random.Range(minSpawningTime,maxSpawningTime);
        GameObject obj = Instantiate(spawnPrefab, this.transform);
        obj.transform.position = new Vector3(valueX, randomY, 0f);
    }
}
