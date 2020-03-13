using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    void Start()
    {   
        
        levelManager = GameObject.FindGameObjectWithTag("level0Manager");//Set level manager to current levelManager object
        levelManagerScripts = levelManager.GetComponent<Level0Manager>();
        
        PlayerMovement = GameObject.FindGameObjectWithTag("Player");//Set playerMovement scripts to current player object
        playerScripts = PlayerMovement.GetComponent<Player>();
        
        myRigidbody = GetComponent<Rigidbody2D>();
        movement = playerScripts.getMovement();// Get movement attribute from Player class
    }


    void FixedUpdate()
    {
        float moveX, moveY;
        
        if (levelManagerScripts.turnManager() == true)//Check if it is player turn
        {
                moveX = Input.GetAxisRaw("Horizontal");
                moveY = Input.GetAxisRaw("Vertical");
                movePlayer(moveX, moveY);
        }

        if (levelManagerScripts.turnManager() == false)//If not players turn, don't move. This prevents other characters from pushing this character
        {
            movePlayer(0, 0);
        }
        
        travelledTotal = getMovement(travelledTotal);
        
        if (travelledTotal >= movement){// Once the player has travelled a certain amount, end their turn
            levelManagerScripts.changeTurn();
            travelledTotal = 0;
        }
    }
    
    void movePlayer(float directionX, float directionY)
    {
            velocity = new Vector2(directionX, directionY);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }

    //Allows other objects to get this objects position
    public float getPositionX(){
        float myPositionX = myRigidbody.position.x;
        return myPositionX;
    }

    public float getPositionY(){
        float myPositionY = myRigidbody.position.y;
        return myPositionY;
    }

    protected override float getMovement(float travelledTotal)
    {
        return base.getMovement(travelledTotal);
    }

}
