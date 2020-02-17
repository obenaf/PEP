using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed;

    private float moveX, moveY, changeTurn;
    private Rigidbody2D myRigidbody;
    private Vector2 velocity;
    public bool PlayerTurn;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        PlayerTurn = true;

    }


    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        changeTurn = Input.GetAxisRaw("ChangeTurn");

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
            velocity = new Vector2(.5f, -.5f);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
        }
        if (directionX == -1)
        {
            velocity = new Vector2(-.5f, .5f);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
        }
        if (directionY == 1)
        {
            velocity = new Vector2(.5f, .5f);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
        }
        if (directionY == -1)
        {
            velocity = new Vector2(-.5f, -.5f);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
        }
        //PlayerTurn = false;
    }
    
}
 //* Time.fixedDeltaTime