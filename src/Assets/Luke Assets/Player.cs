using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public bool PlayerTurn;
    public Vector2 newposition;
    public Vector2 oldposition;

    public float moveX, moveY, changeTurn;

    private Rigidbody2D myRigidbody;
    private Vector2 velocity;
    
    public bool moving;
    private float newpositionX, newpositionY;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        PlayerTurn = true;
    }
//

    void Update()
    {
        changeTurn = Input.GetAxisRaw("ChangeTurn");
        if(moving == false){
                moveX = Input.GetAxisRaw("Horizontal");
                moveY = Input.GetAxisRaw("Vertical");
                newposition = new Vector2(0f, 0f);
                if (moveX == 1)
                {
                    newposition = new Vector2(.5f, 0f);
                }
                if (moveX == -1)
                {
                    newposition = new Vector2(-.5f, 0f);
                }
                if (moveY == 1)
                {
                    newposition = new Vector2(0f, .5f);
                }
                if (moveY == -1)
                {
                    newposition = new Vector2(0f, -.5f);
                }
                oldposition = myRigidbody.position;
                newposition = newposition + myRigidbody.position;
        }
        if (PlayerTurn == true)
        {
            
            if (moveX != 0)
            {
                movePlayer(moveX, 0);
            }
            if (moveY != 0)
            {
                movePlayer(0, moveY);
            }
        }
        if (changeTurn == 1)
        {
            PlayerTurn = true;
        }
        

    }
    //move Player = Direction needs to be a 
    void movePlayer(float directionX, float directionY)
    {
        if (directionX == 1)
        {
            velocity = new Vector2(directionX, 0);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);             
        }
        if (directionX == -1)
        {
            velocity = new Vector2(directionX, 0);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);   
        }
        if (directionY == 1)
        {
            velocity = new Vector2(0, directionY);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
        }
        if (directionY == -1)
        {
            velocity = new Vector2(0, directionY);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
        }
        moving = true;
        if (myRigidbody.position == newposition){
            moving = false;
            PlayerTurn = false;
        }   
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collision")
        {
            myRigidbody.position = oldposition;
            moving = false;            
        }
    }   
}