using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballActivate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FireBall fireBall = collision.gameObject.GetComponent<FireBall>();
            if (fireBall != null)
            {
                fireBall.enabled = true;
                Destroy(gameObject);        
            }
        }
    }
}
