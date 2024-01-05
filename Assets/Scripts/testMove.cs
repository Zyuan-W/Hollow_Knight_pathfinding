using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{
    private Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {        



    }

    public void getAttack()
    {
        rb.AddForce(new Vector2(-5, 5), ForceMode2D.Impulse);
    }
}
