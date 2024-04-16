using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class GruzMother : Enemy
{
    private Rigidbody2D rb;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Flip();
        if (isFacingRight)
        {
            rb.velocity = Vector2.right * moveSpeed;
        }else
        {
            rb.velocity = Vector2.left * moveSpeed;
        }
    }

    private void Flip()
    {
        // if the enemy is at position (-13.18, 4.03), flip the enemy
        if (transform.position.x <= -13.18)
        {
            isFacingRight = true;
            // Vector3 vector = transform.localScale;
            // vector.x *= -1;
            transform.localScale = new Vector3(1f, -1f, 1f);
        }else if (transform.position.x >= 11.15)
        {
            isFacingRight = false;
            // Vector3 vector = transform.localScale;
            // vector.x *= -1;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
