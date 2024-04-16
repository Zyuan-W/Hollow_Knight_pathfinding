using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class TraceFireball : MonoBehaviour
{
    // private PlayerController playerController;

    public GameObject traceFireBallPrefab;

    public float fireBallSpeed = 5f;

    public float fireBallFrequency;

    public float fireBallLifeTime = 8f;

    // private TraceFireballBehavior traceFireballBehavior;
    // private HitCounter hitCounter;


   
    void Start()
    {
        // hitCounter = GameObject.FindObjectOfType<HitCounter>();
        ShootTraceFireBall();
        StartCoroutine(ShootFireballRoutine());
    }

    IEnumerator ShootFireballRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireBallFrequency);
            ShootTraceFireBall(); 

            // int hitCount = hitCounter.GetHitsCount();
            // check if boss has been hit 3 times to increase the shooting frequency
            // if (hitCount >= 3 && fireBallFrequency >= 1.5f)
            // {
                
            //     Debug.Log("Boss has been hit 3 times, increasing fireball frequency");
            //     fireBallFrequency = fireBallFrequency / 2;
            // }
        }
    }

    void ShootTraceFireBall()
    {
        // playerController = GameObject.FindObjectOfType<PlayerController>();
        // bool isFancingRight = playerController.GetFacingDirection();
        // Vector2 shootDirection = isFancingRight ? Vector2.right : Vector2.left;
        Vector2 shootDirection = Vector2.down;

        GameObject traceFireBall = Instantiate(traceFireBallPrefab, (Vector2)transform.position + (Vector2)shootDirection, Quaternion.identity);
        
        traceFireBall.layer = LayerMask.NameToLayer("TraceFireball");
        // Rigidbody2D rb = traceFireBall.GetComponent<Rigidbody2D>();
        // rb.velocity = shootDirection * 5f;
        Destroy(traceFireBall, fireBallLifeTime);
    }
}
