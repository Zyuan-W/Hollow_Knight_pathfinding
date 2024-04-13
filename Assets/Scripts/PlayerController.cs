using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Vector3 flippedScale = new Vector3(-1, 1, 1);

    private bool isFancingRight;

    private Rigidbody2D rb;
    private Animator animator;

    const float JUMPTIMER = 0.3f;

    float moveSpeed = 10f;
    float jumpTimer = 0.3f;
    public float impulseJumpForce = 5.0f;
    public float continuousJumpForce = 2.0f;
    [SerializeField] float hurtForce = 1f;
    bool isOnGround;

    int moveChangeAnim;
    float moveChange;

    float moveX;
    float moveY;

    private CinemaShaking cinemaShaking;

    // public char jumpButton = 'z';
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cinemaShaking = FindObjectOfType<CinemaShaking>();
        hurtAct();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.X))
        // {
        //     TakeDamage();
        // }
        Movement();
        Direction();
        Jump();

        // rb.AddForce(new Vector2(10,10), ForceMode2D.Impulse);
        // test();
    }

    public bool GetFacingDirection()
    {
        return isFancingRight;
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("press z once");
            rb.AddForce(new Vector2(0, impulseJumpForce), ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log("keep pressing z");
            float s_time = Time.deltaTime * 1.4f;
            // jumpTimer -= Time.deltaTime;
            jumpTimer -= s_time;
            if (jumpTimer > 0)
            {
                rb.AddForce(new Vector2(0, continuousJumpForce), ForceMode2D.Force);
                animator.SetTrigger("jump");
            }
        }
    }
    // enter ground
    private void OnCollisionEnter2D(Collision2D collision)
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
                JumpCancle();
            } else if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain") && isOnGround && collision.contacts[0].normal == Vector2.down)
            {
                JumpCancle();
            }
        }
        animator.SetBool("isOnGround", isOnGround);
    }

    private void JumpCancle()
    {
        Debug.Log("jump cancle");
        animator.ResetTrigger("jump");
        jumpTimer = JUMPTIMER;
    }
    public void TakeDamage()
    {
        Debug.Log("Player take damage");
        cinemaShaking.CinemaShake();
        StartCoroutine(GetComponent<Invisibility>().SetInvincibility());
        FindObjectOfType<Health>().Hurt();

        // if (isFancingRight)
        // {

        //     rb.velocity = new Vector2(1, 1) * hurtForce;

        // } else 
        // {
        //     rb.velocity = new Vector2(-1, 1) * hurtForce;
        // }
        hurtAct();


        animator.Play("TakeDamage");

    }

    private void hurtAct()
    {
        Debug.Log("hurt act");
        // rb.AddForce(new Vector2(-1, 0) * hurtForce, ForceMode2D.Impulse);
        rb.velocity = new Vector2(-1, 0) * hurtForce;
    }

    // private void test()
    // {
    //     // if facing right move toward to (1,1)
    //     if (isFancingRight)
    //     {
    //         rb.velocity = new Vector2(1, 1) * 3;
    //     }

    //     // press c let object move to right 
    //     // if (Input.GetKeyDown(KeyCode.C))
    //     // {
    //     //     Debug.Log("press c");
    //     //     transform.Translate(5 * Time.deltaTime, 0, 0);
    //     // }
    // }
}
