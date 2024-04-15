using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject defenceWall;
    public float defenceLifeTime = 3f;
    public float dist = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DefendWall();
        }
    }

    void DefendWall()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        Vector2 defendDirection = new Vector2(0, dist);
        GameObject defence = Instantiate(defenceWall, (Vector2)transform.position + (Vector2)defendDirection, Quaternion.identity);
        defence.layer = LayerMask.NameToLayer("Block");
        Destroy(defence, defenceLifeTime);
    }
}
