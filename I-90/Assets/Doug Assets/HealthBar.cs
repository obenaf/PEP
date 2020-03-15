using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Learned how to make a health bar from: https://www.youtube.com/watch?v=Gtw7VyuMdDc
public class HealthBar : MonoBehaviour
{
    private Transform bar;
    
    private void Start()
    {
        bar = transform.Find("Bar");
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
