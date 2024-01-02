using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{

    public SpriteRenderer render;
    public Color normalColor;
    public Color flashColor;
    public int duration;
    public bool isInvincible;

    public IEnumerator SetInvincibility()
    {
        isInvincible = true;
        for (int i = 0; i < duration; i++)
        {
            yield return new WaitForSeconds(0.1f);
            render.color = flashColor;
            yield return new WaitForSeconds(0.2f);
            render.color = normalColor;
        }
        isInvincible = false;
    }
}
