using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private GameObject memorySpawnPrefab;
    [SerializeField] private GameObject bulletPrefab;
    private GameObject player;
    public float minY;
    public float maxY;
    public float valueX;
    public float minSpawningTime = 0.5f;
    public float maxSpawningTime = 0.8f;
    public float minSpawningTimeMemory = 3.5f;
    public float maxSpawningTimeMemory = 5f;
    private float randomSpawningTime;
    private float randomSpawningTimeMemory;
    public float timer = 0f;
    public float memoryTimer = 0f;
    private bool spawn = false;

    // Update is called once per frame
    void Start(){
        KayakingGameManager.GameOver += dontSpawn;
        KayakingGameManager.GameStart += startToSpawn;
        InputSystem.spacePressed += SpawnBullet;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnDestroy(){
        KayakingGameManager.GameOver -= dontSpawn;
        KayakingGameManager.GameStart -= startToSpawn;
        InputSystem.spacePressed -= SpawnBullet;
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
        if(memoryTimer > randomSpawningTimeMemory && spawn){
            SpawnMemory();
            memoryTimer = 0f;
        }
        memoryTimer += 0.01f;
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

    private void SpawnMemory(){
        float randomY = Random.Range(minY, maxY);
        this.randomSpawningTimeMemory = Random.Range(minSpawningTimeMemory,maxSpawningTimeMemory);
        GameObject obj = Instantiate(memorySpawnPrefab, this.transform);
        obj.transform.position = new Vector3(valueX, randomY, 0f);
    }

    private void SpawnBullet(){
        if(EpisodeManager.instance.secondEpisode){
        GameObject bullet = Instantiate(bulletPrefab, player.transform);
        }
    }
}
