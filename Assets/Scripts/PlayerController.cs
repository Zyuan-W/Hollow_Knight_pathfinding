using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 flippedScale = new Vector3(-1, 1, 1);

    bool isFancingRight;

    private Rigidbody2D rb;
    private Animator animator;

    float moveSpeed = 10f;
    float jumpForce = 1f;
    // float jumpTimer = 1f;
    [SerializeField] float hurtForce = 1f;
    bool isOnGround;

    int moveChangeAnim;
    float moveChange;

    float moveX;
    float moveY;

    // public char jumpButton = 'z';
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage();
        }
        Movement();
        Direction();
        Jump();
        // test();
    }

    private void Movement()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (moveX > 0)
        {
            isFancingRight = true;
            moveChangeAnim = 1;
        } else if (moveX < 0)
        {
            isFancingRight = false;
            moveChangeAnim = -1;
        } else
        {
            moveChangeAnim = 0;
        }

        animator.SetInteger("movement", moveChangeAnim);

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

    private void Jump()
    { 
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce * 20), ForceMode2D.Impulse);

            animator.SetTrigger("jump");

        }
    }
    // enter ground
    private void OnConllisionEnter2D(Collision2D collision)
    {
        Grounding(collision, false);
    }
    // stay on ground
    private void OnCollisionStay2D(Collision2D collision)
    {
        Grounding(collision, false);
    }
    // exit ground
    private void OnCollisionExit2D(Collision2D collision)
    {
        Grounding(collision, true);
    }
    private void Grounding(Collision2D collision, bool exitState)
    {
        if (exitState)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
            {
                isOnGround = false;
            }
        }
        else 
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain") && !isOnGround && collision.contacts[0].normal == Vector2.up)
            {
                isOnGround = true;
            } else if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain") && isOnGround && collision.contacts[0].normal == Vector2.down)
            {
                JumpCancle();
            }
        }
        animator.SetBool("isOnGround", isOnGround);
    }

    private void JumpCancle()
    {
        animator.ResetTrigger("jump");
    }
    private void TakeDamage()
    {
        StartCoroutine(GetComponent<Invisibility>().SetInvincibility());
        FindObjectOfType<Health>().Hurt();
        Debug.Log("TakeDamage isFacingRight: " + isFancingRight);

        if (isFancingRight)
        {
            Debug.Log("right_Takedamage");

            rb.velocity = new Vector2(1 , 1) * hurtForce;

        } else 
        {
            rb.velocity = new Vector2(-1, 1) * hurtForce;
        }

        animator.Play("TakeDamage");

    }

    // private void test()
    // {
    //     // press c let object move to right 
    //     if (Input.GetKeyDown(KeyCode.C))
    //     {
    //         Debug.Log("press c");
    //         transform.Translate(5 * Time.deltaTime, 0, 0);
    //     }
    // }
}
