using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed;

    float range;
    float height;
    string inputY;
    string inputX;
    
    void Start()
    {
        height = transform.localScale.y;
        range = transform.localScale.x;
        speed = 5f;
        inputY = "Vertical";
        inputX = "Horizontal";
      
    }

    
    void Update()
    {
        float moveY = Input.GetAxis(inputY) * Time.deltaTime * speed;
        transform.Translate(moveY * Vector2.up);
        float moveX = Input.GetAxis(inputX) * Time.deltaTime * speed;
        transform.Translate(moveX * Vector2.right);
    }
}
