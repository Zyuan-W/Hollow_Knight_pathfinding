using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceFireballActivate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TraceFireball traceFireball = collision.gameObject.GetComponent<TraceFireball>();
            if (traceFireball != null)
            {
                traceFireball.enabled = true;
                Destroy(gameObject);        
            }
        }
    }
}
