using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{
    public Rigidbody2D rb;
    private Rigidbody2D rb2;
    float moveX;
    float moveY;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {    
        // axis 
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveX * 3, rb.velocity.y);
        rb2.velocity = new Vector2(moveX * 3, rb2.velocity.y);

        rb.velocity = new Vector2(rb.velocity.x, moveY * 3);
        

    
        if (Input.GetKeyDown(KeyCode.C))
        {
            rb.velocity = new Vector2(3, 0);
            rb2.velocity = new Vector2(3, 0);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            rb.velocity = new Vector2(0, 3);
            rb2.velocity = new Vector2(0, 3);
        }


    }
}
