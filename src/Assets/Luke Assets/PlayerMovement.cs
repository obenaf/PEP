using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameObject levelManager;//Call methods from the Level0Manager.cs
    Level0Manager levelManagerScripts;

    GameObject player;//Call methods from the Player.cs
    Player playerScripts;

    [SerializeField]
    public float speed;
    public float movement, travelledX, travelledY, travelledTotal;

    private Rigidbody2D myRigidbody;
    private Vector2 velocity;
    private float oldpositionX, oldpositionY;
    
    

    void Start()
    {   
        /////////////// Create Object to call from Level0Manager
        levelManager = GameObject.FindGameObjectWithTag("level0Manager");
        levelManagerScripts = levelManager.GetComponent<Level0Manager>();
        /////////////// Create Object to call from Player
        player = GameObject.FindGameObjectWithTag("Player");
        playerScripts = player.GetComponent<Player>();
        ///////////////
        myRigidbody = GetComponent<Rigidbody2D>();
        movement = playerScripts.getMovement();
    }


    void Update()
    {
        float moveX, moveY;
        
        if (levelManagerScripts.turnManager() == true)//Check if it is player turn
        {
                moveX = Input.GetAxisRaw("Horizontal");
                moveY = Input.GetAxisRaw("Vertical");
                movePlayer(moveX, moveY);
        }
        ////Calculate the distance moved per frame and keep a total in travelledtotal
        travelledX = Mathf.Abs(myRigidbody.position.x - oldpositionX);
        travelledY = Mathf.Abs(myRigidbody.position.y - oldpositionY);
        travelledTotal = travelledY + travelledX + travelledTotal;

        ////If travelledTotal becomes larger than player's movment, end the player's turn
        if (travelledTotal >= movement){
            levelManagerScripts.changeTurn();
            travelledTotal = 0;
        }
        
        ///Sets current postion in oldposition so that oldposition can be used next frame when the current position has changed
        oldpositionX = myRigidbody.position.x;
        oldpositionY = myRigidbody.position.y;

    }
    void movePlayer(float directionX, float directionY)
    {
            velocity = new Vector2(directionX, directionY);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
