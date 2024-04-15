using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceFireball : MonoBehaviour
{
    private PlayerController playerController;

    public GameObject traceFireBallPrefab;

    public float fireBallLifeTime = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootTraceFireBall();
        }
    }

    void ShootTraceFireBall()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        bool isFancingRight = playerController.GetFacingDirection();
        Vector2 shootDirection = isFancingRight ? Vector2.right : Vector2.left;

        GameObject traceFireBall = Instantiate(traceFireBallPrefab, (Vector2)transform.position + (Vector2)shootDirection, Quaternion.identity);
        
        traceFireBall.layer = LayerMask.NameToLayer("Fireball");
        // Rigidbody2D rb = traceFireBall.GetComponent<Rigidbody2D>();
        // rb.velocity = shootDirection * 5f;
        Destroy(traceFireBall, fireBallLifeTime);
    }
}
