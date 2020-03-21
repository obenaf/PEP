using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : Movement
{
    public GameObject playerMovement;
    public PlayerMovement playerMovementScripts;
    public int direction;
    public int moveCounter = 1;
    //public int moveUpdateCounter = 0;
    public bool changeDir = false;
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("level0Manager");
        levelManagerScripts = levelManager.GetComponent<Level0Manager>();

        //playerScript = Player.GetComponent<>;
        playerMovement = GameObject.FindGameObjectWithTag("Player");
        //PlayerMovement = GameObject.FindGameObjectWithTag("Player");
        playerMovementScripts = playerMovement.GetComponent<PlayerMovement>();

        allEnemies = GameObject.FindObjectsOfType<Enemy>();//changed - allEnemies is inherited from Movement class
        foreach (Enemy currentEnemy in allEnemies)
        {
            enemyScripts = currentEnemy.GetComponent<Enemy>();//changed
        }

        myRigidbody = GetComponent<Rigidbody2D>();
        movement = enemyScripts.getMovement();//changed
    }


    void FixedUpdate()
    {
        float MoveX, MoveY;
        
        float playerPosX = playerMovementScripts.getPositionX();
        float playerPosY = playerMovementScripts.getPositionY();
        float currentPosX = getPositionX();
        float currentPosY = getPositionY();
        float movementX = playerPosX - currentPosX;
        float movementY = playerPosY - currentPosY;
        if (levelManagerScripts.turnManager() == false)
        {
            travelledTotal = getMovement(travelledTotal);
            if (travelledTotal %2 >= 1)
            {
                changeDir = true;
                direction = Random.Range(1, 9);
            }
            else
            {
                changeDir = false;
            }
            // Move only every 5 frames (assuming 60)
            if (moveCounter == 5)
            {
                // Player is more than 5 units away so move in a random direction
                if (Mathf.Pow(movementX, 2) + Mathf.Pow(movementY, 2) > 5)
                {
                    /*if (moveUpdateCounter % 60 == 1)
                    {
                        direction = Random.Range(1, 5);
                        moveUpdateCounter = 0;
                    }*/
                    switch (direction)
                    {
                        // Right
                        case 1:
                            MoveX = 1;
                            MoveY = 0;
                            break;
                        // Up
                        case 2:
                            MoveX = 0;
                            MoveY = 1;
                            break;
                        // Left
                        case 3:
                            MoveX = -1;
                            MoveY = 0;
                            break;
                        // Down
                        case 4:
                            MoveX = 0;
                            MoveY = -1;
                            break;
                        // Up right
                        case 5:
                            MoveX = 1;
                            MoveY = 1;
                            break;
                        // Up left
                        case 6:
                            MoveX = -1;
                            MoveY = 1;
                            break;
                        // Down left
                        case 7:
                            MoveX = -1;
                            MoveY = -1;
                            break;
                        // Down right
                        case 8:
                            MoveX = 1;
                            MoveY = -1;
                            break;
                        default:
                            MoveX = 0;
                            MoveY = 0;
                            break;
                    }
                }
                // Player is within 5 units so move towards them
                else
                {

                    //if (EnemyTurn == true)
                    //{
                    //    moveEnemy(moveX, moveY);
                    //}
                    //if (changeTurn == 1)
                    //{
                    //    EnemyTurn = true;
                    // }
                    //MoveX = Input.GetAxisRaw("Horizontal");
                    //MoveY = Input.GetAxisRaw("Vertical");
                    //moveEnemy(MoveX, MoveY);


                    // Update enemy movement in X direction
                    if (movementX > 0.3)
                    {
                        MoveX = 1;
                    }
                    else if (movementX < 0.3)
                    {
                        MoveX = -1;
                    }
                    else
                    {
                        MoveX = 0;
                    }

                    // Update enemy movement in Y direction
                    if (movementY > 0.3)
                    {
                        MoveY = 1;
                    }
                    else if (movementY < 0.3)
                    {
                        MoveY = -1;
                    }
                    else
                    {
                        MoveY = 0;
                    }

                    if ((movementX < 0.3) && (movementY <0.3) )
                    {
                        MoveY = 0;
                        MoveX = 0;
                        travelledTotal++;
                    }
                    
                }
                moveEnemy(MoveX, MoveY);
                moveCounter = 1;
                //moveUpdateCounter++;
            }
            else
            {
                //moveUpdateCounter++;
                moveCounter++;
            }
            
        }
        if (levelManagerScripts.turnManager() == true)//If not players turn, don't move. This prevents other characters from pushing this character
        {
            moveEnemy(0, 0);
        }

        //travelledTotal = getMovement(travelledTotal);

        if (travelledTotal >= movement)
        {
            levelManagerScripts.changeTurn();
            travelledTotal = 0;
        }

    }

    void moveEnemy(float directionX, float directionY)
    {
        velocity = new Vector2(5*directionX, 5*directionY);
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }

    public float getPositionX()
    {
        float myPositionX = myRigidbody.position.x;
        return myPositionX;
    }

    public float getPositionY()
    {
        float myPositionY = myRigidbody.position.y;
        return myPositionY;
    }

    protected override float getMovement(float travelledTotal)
    {
        return base.getMovement(travelledTotal);
    }
    
}
