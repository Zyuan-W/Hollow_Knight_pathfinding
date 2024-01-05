using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : Enemy
{
    private Rigidbody2D rb;
    public Collider2D facingDetector;
    public ContactFilter2D contact;
    public float moveSpeed;
    public GameObject groundCheck;
    public int circleRadius;
    public LayerMask ground;
    public float hurtForce;
    bool forceMovement;
    bool isFacingRight;
    bool isDead;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Direction();
        Movement();
        FacingDetect();

    }

    private void Direction()
    {
        if (transform.localScale.x == 1)
        {
            isFacingRight = true;
        } else if (transform.localScale.x == -1)
        {
            isFacingRight = false;
        }
    }

    private void Movement()
    {
        if (!isDead)
        {
            if (isFacingRight)
            {
                rb.velocity = Vector2.right * moveSpeed;
            }else
            {
                rb.velocity = Vector2.left * moveSpeed;
            }
        }
    }

    private void FacingDetect()
    {
        if(isDead)
        {
            return;
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadius, ground);

        if(!isGrounded)
        {
            Flip();
        } else
        {
            int count = Physics2D.OverlapCollider(facingDetector, contact, new List<Collider2D>());
            if (count > 0)
            {
                Flip();
            }
        }

    }

    private void Flip()
    {
        Vector3 vector = transform.localScale;
        vector.x *= -1;
        transform.localScale = vector;

    }

    public override void Hurt(int damage, Transform attackPosition)
    {
        base.Hurt(damage);
        Vector2 vector = transform.position - attackPosition.position;
        StartCoroutine(DelayHurt(vector));
    }

    IEnumerator DelayHurt(Vector2 vector)
    {
        rb.velocity = Vector2.zero;
        forceMovement = false;
        if (vector.x > 0)
        {
            rb.AddForce(new Vector2(hurtForce, 0), ForceMode2D.Impulse);
        } else 
        {
            rb.AddForce(new Vector2(-hurtForce, 0), ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(0.3f);
        forceMovement = true;
    }
}
