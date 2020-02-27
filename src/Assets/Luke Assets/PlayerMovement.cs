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
    public float movement, travelledX, travelledY, travelledtotal;

    private Rigidbody2D myRigidbody;
    private Vector2 velocity;
    private float oldpositionX, oldpositionY;
    
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("level0Manager");
        levelManagerScripts = levelManager.GetComponent<Level0Manager>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerScripts = player.GetComponent<Player>();
        
        myRigidbody = GetComponent<Rigidbody2D>();
        movement = playerScripts.getMovement();
    }


    void Update()
    {
        float moveX, moveY, changeTurn;
        changeTurn = Input.GetAxisRaw("ChangeTurn");
        
        if (levelManagerScripts.turnManager() == true)
        {
                moveX = Input.GetAxisRaw("Horizontal");
                moveY = Input.GetAxisRaw("Vertical");
                movePlayer(moveX, moveY);
        }
        if (changeTurn == 1)
        {
            levelManagerScripts.changeTurn();
        }

        travelledX = Mathf.Abs(myRigidbody.position.x - oldpositionX);
        travelledY = Mathf.Abs(myRigidbody.position.y - oldpositionY);
        travelledtotal = travelledY + travelledX + travelledtotal;

        if (travelledtotal >= movement){
            levelManagerScripts.changeTurn();
            travelledtotal = 0;
        }

        oldpositionX = myRigidbody.position.x;
        oldpositionY = myRigidbody.position.y;

    }
    void movePlayer(float directionX, float directionY)
    {
            velocity = new Vector2(directionX, directionY);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
