using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;

public class FireBall : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject fireBallPrefab;
    public float fireBallSpeed = 5f;
    public float fireBallLifeTime = 2f;
    // public Vector2 shootDirection = Vector2.right;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootFireBall();
        }
    }

    void ShootFireBall()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        bool isFancingRight = playerController.GetFacingDirection();
        Vector2 shootDirection = isFancingRight ? Vector2.right : Vector2.left;

        GameObject fireBall = Instantiate(fireBallPrefab, (Vector2)transform.position + (Vector2)shootDirection, Quaternion.identity);
        
        fireBall.layer = LayerMask.NameToLayer("Fireball");
        Rigidbody2D rb = fireBall.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * fireBallSpeed;
        Destroy(fireBall, fireBallLifeTime);
    }

}
