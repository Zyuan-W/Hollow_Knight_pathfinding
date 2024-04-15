using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TestTrigger : MonoBehaviour
{

    public Rigidbody2D rb;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered the testTrigger");
            // AstarPath.active.Scan();
            rb.gravityScale = 1;
        }
    }


    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
