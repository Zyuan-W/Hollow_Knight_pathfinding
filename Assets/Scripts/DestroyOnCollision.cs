using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private EnemyManager enemyManager;

    private void Start()
    {
        enemyManager = GameObject.FindObjectOfType<EnemyManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy(gameObject);
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);
            enemyManager.RespawnEnemy();
        } else 
        {
            Destroy(gameObject);
        }
    }
}
