using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    public void RespawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Enemy Respawned");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
