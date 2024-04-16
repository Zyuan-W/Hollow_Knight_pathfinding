using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using TMPro.Examples;


public class TraceFireballBehavior : MonoBehaviour
{
    // private EnemyManager enemyManager;
    private PlayerController playerController;
    private FireballAI fireballAI;
    public GameObject enemy;

    private Rigidbody2D rb;

    private CapsuleCollider2D fireballCollider;
    private CapsuleCollider2D bossCollider;

    public float reboundForce = 5f;

    // public int hitBoss = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindWithTag("Boss");
        playerController = GameObject.FindObjectOfType<PlayerController>();

        fireballCollider = GetComponent<CapsuleCollider2D>();

        // fireballCollider = GetComponent<Collider>();
        bossCollider = enemy.GetComponent<CapsuleCollider2D>();
        Physics2D.IgnoreCollision(fireballCollider, bossCollider, true);

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

        if (collision.gameObject.tag == "Block")
        {
            Debug.Log("Fireball hit the Block");
            // hitBoss += 1;
            // Debug.Log("Hit Boss: " + hitBoss);
            fireballAI = GameObject.FindObjectOfType<FireballAI>();
            // enemy = GameObject.FindWithTag("Boss");
            fireballAI.target = enemy.transform;

            // fireballAI.enabled = false;

            // // give object a up force
            // rb = GetComponent<Rigidbody2D>();
            //get the direction of the fireball
            // Vector2 direaction = rb.velocity.normalized;
            // Debug.Log("Fireball direction: " + direaction);

            Vector2 direction = fireballAI.getDirection();
            // Debug.Log("Fireball direction2: " + direction);
            //reverse the direction
            Vector2 reboundVelocity = -direction * reboundForce;
            // print the direction
            // Debug.Log("Rebound direction: " + reboundVelocity);
            rb.velocity = reboundVelocity;

            // Debug.Log("Fireball rebound");

            fireballAI.speed = 700f;

            // activate collider
            Physics2D.IgnoreCollision(fireballCollider, bossCollider, false);

            // get this object
            // this.gameObject.layer = LayerMask.NameToLayer("newTraceFireball");

        }

        if (collision.gameObject.tag == "Boss")
        {
            Debug.Log("Fireball hit the Boss");
            Destroy(gameObject);
        }
    }

    
}
