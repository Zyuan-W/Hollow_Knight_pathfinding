using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 flippedScale = new Vector3(-1, 1, 1);

    float moveX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Movement()
    {
        moveX = Input.GetAxis("Horizontal");


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
