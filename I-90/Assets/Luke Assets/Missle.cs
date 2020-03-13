using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public float speed = 1.0f;
    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }       

    }
}
