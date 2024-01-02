using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Animator[] healthItems;
    public Animator geo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt()
    {
        healthItems[0].SetTrigger("hurt");
    }

    public IEnumerator ShowHealthItems()
    {
        for (int i = 0; i < healthItems.Length; i++)
        {
            healthItems[i].SetTrigger("respown");
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.2f);
        geo.Play("enter");

    }
    
    public void HideHealthItems()
    {
        geo.Play("exit");
        for (int i = 0; i < healthItems.Length; i++)
        {
            healthItems[i].SetTrigger("hide");
        }
    }
}
