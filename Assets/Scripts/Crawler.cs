using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : Enemy
{
    private Rigidbody2D rb;
    private Animator anime;
    private Collider2D crawlerCollider;
    public Collider2D facingDetector;
    public ContactFilter2D contact;
    public float moveSpeed;
    public GameObject groundCheck;
    public int circleRadius;
    public LayerMask ground;
    public float hurtForce;
    public float deadForce;
    bool forceMovement = true;
    // bool isFacingRight;
    // bool isDead;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        crawlerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Direction();
        Movement();
        FacingDetect();
        CrawlerAttack();

    }

    // private void Direction()
    // {
    //     if (transform.localScale.x == 1)
    //     {
    //         isFacingRight = true;
    //     } else if (transform.localScale.x == -1)
    //     {
    //         isFacingRight = false;
    //     }
    // }

    private void Movement()
    {
        if (!isDead && forceMovement)
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

        if(!isGrounded) // no floor
        {
            Flip();
        } else 
        {
            int count = Physics2D.OverlapCollider(facingDetector, contact, new List<Collider2D>());
            Debug.Log("Crawler contact " + count + " objects");
            // get the tag of collider object
            Collider2D[] colliders = new Collider2D[10];
            count = facingDetector.OverlapCollider(contact, colliders);
            bool isPlayer = false;
            // if (colliders[0] != null)
            // {
                if (colliders[0].gameObject.tag.CompareTo("Player") == 0)
                {
                    Debug.Log("Crawler contact player");
                    isPlayer = true;
                }
            // }else {
            //     count = 0;
            // }
            // if (colliders[0].gameObject.tag.CompareTo("Player") == 0)
            // {
            //     Debug.Log("Crawler contact player");
            //     isPlayer = true;
            // }
            if (count > 0 && !isPlayer)
            {
                // StartCoroutine(DelayFlip());
                Flip();
                Debug.Log("enemy attack test");
                FindObjectOfType<testMove>().getAttack();
            }
        }

    }

    private void CrawlerAttack()
    {
        Collider2D[] colliders = new Collider2D[10];
        int count = crawlerCollider.OverlapCollider(contact, colliders);
        for (int i = 0; i < count; i++)
        {
            if (colliders[i].gameObject.tag == "Player")
            {
                // FindObjectOfType<PlayerController>().TakeDamage();
                // stop move for 0.3s
                Flip();

            }
        }

    }

    // IEnumerator DelayFlip()
    // {
    //     yield return new WaitForSeconds(0.1f);
    //     Flip();
    // }

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

    protected override void Dead()
    {
        base.Dead();
        StartCoroutine(DelayDead());

    }

    IEnumerator DelayDead()
    {
        Vector3 diff = (GameObject.FindWithTag("Player").transform.position - transform.position).normalized;
        rb.velocity = Vector2.zero;
        if (diff.x < 0)
        {
            rb.AddForce(Vector2.right * deadForce, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.left * deadForce, ForceMode2D.Impulse);
        }
        if (anime != null)
        {
            anime.SetBool("Dead", true);
        }
        yield return new WaitForSeconds(0.2f);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; // unenable rb
        GetComponent<BoxCollider2D>().enabled = false; // unenable collider

    }
}
