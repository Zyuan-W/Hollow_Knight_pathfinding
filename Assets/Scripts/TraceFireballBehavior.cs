using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceFireballBehavior : MonoBehaviour
{
    // private EnemyManager enemyManager;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy(gameObject);
        if (collision.gameObject.tag == "Player")
        {

            // Destroy(collision.gameObject);
            Destroy(gameObject);
            playerController.TakeDamage();
            // enemyManager.DestroyOneEnemy();
            // enemyManager.RespawnEnemy();
        // } else 
        // {
        //     Destroy(gameObject);
        }
    }
}
