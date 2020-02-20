using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public bool PlayerTurn;

    private float moveX, moveY, changeTurn;
    private Rigidbody2D myRigidbody;
    private Vector2 velocity;
    private bool moving;
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
                
                newpositionX = myRigidbody.position.x +.5f;
                newpositionY = myRigidbody.position.y -.25f;
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
            velocity = new Vector2(.5f, -.25f);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
            if (myRigidbody.position.x == newpositionX){
                moving = false;
                PlayerTurn = false;
            }                
        }
        if (directionX == -1)
        {
            velocity = new Vector2(-.5f, .25f);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
        }
        if (directionY == 1)
        {
            velocity = new Vector2(.5f, .25f);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
        }
        if (directionY == -1)
        {
            velocity = new Vector2(-.5f, -.25f);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
        }
        
        moving = true;
    }
    
}
 //* Time.fixedDeltaTime