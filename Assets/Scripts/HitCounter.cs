using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCounter : MonoBehaviour
{
    // Start is called before the first frame update
    private int hitsCount = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Hit Boss");
        if (hitsCount >= 3)
        {
            // reset the hit count
            hitsCount = 0;
        }
        if (collision.gameObject.tag == "TraceFireball")
        {
            hitsCount += 1;
            // Debug.Log("Hit Boss: " + hitsCount);
        }
    }

    public int GetHitsCount()
    {
        return hitsCount;
    }
}
