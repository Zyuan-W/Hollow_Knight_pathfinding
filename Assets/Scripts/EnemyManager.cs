using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject mainCamera;
    public GameObject secondCamera;
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    public Vector2 BossSpawnPosition;

    private int respawnTimes = 0;

    private List<GameObject> activeEnemies = new List<GameObject>();

    void Start()
    {
        // Spawn initial enemy when the game starts
        // SpawnInitialEnemy();
    }

    // private void SpawnInitialEnemy()
    // {
    //     Vector2 initialSpawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    //     var initialEnemy = Instantiate(enemyPrefab, initialSpawnPosition, Quaternion.identity);
    //     activeEnemies.Add(initialEnemy);  // Add the initial enemy to the list
    //     Debug.Log("Initial enemy spawned");
    // }
    // public void RespawnEnemy()
    // {

    //     if (respawnTimes >= 3)
    //     {
    //         Debug.Log("Enemy respawn more than 2 times");
    //         return;
    //     }
    //     Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    //     var enemy1 = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    //     var enemy2 = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    //     activeEnemies.Add(enemy1);
    //     activeEnemies.Add(enemy2);
    //     respawnTimes++;
    //     Debug.Log("Enemy Respawned");
    // }

    public void DestroyOneEnemy()
    {
        activeEnemies.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (activeEnemies.Count == 0)
        {
            Debug.Log("No active flys, spawing Boss.");
            BossSpawnPosition = new Vector2(-1.0f, 4.19f);
            var newBoss = Instantiate(enemyPrefab2, BossSpawnPosition, Quaternion.Euler(0, 180, 90));
            activeEnemies.Add(newBoss);  // Adding the new enemy to the list

            // Switching the camera
            mainCamera.SetActive(false);
            secondCamera.SetActive(true);


        }
    }
}
