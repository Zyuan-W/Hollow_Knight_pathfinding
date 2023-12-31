using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 flippedScale = new Vector3(-1, 1, 1);

    private Rigidbody2D rb;

    float moveSpeed = 10f;

    float moveX;
    float moveY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Direction();
    }

    private void Movement()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);




    }

    private void Direction()
    {
        if (moveX > 0)
        {
            transform.localScale = flippedScale;
        } else if (moveX < 0)
        {
            transform.localScale = Vector3.one;
        }
    }
}
