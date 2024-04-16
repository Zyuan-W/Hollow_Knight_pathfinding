using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceFireball : MonoBehaviour
{
    // private PlayerController playerController;

    public GameObject traceFireBallPrefab;

    public float fireBallSpeed = 5f;

    public float fireBallFrequency = 3f;

    public float fireBallLifeTime = 8f;

   
    void Start()
    {
        ShootTraceFireBall();
        StartCoroutine(ShootFireballRoutine());
    }

    IEnumerator ShootFireballRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireBallFrequency);
            ShootTraceFireBall();
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
