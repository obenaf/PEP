using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SoldierMovement Inherits from the Movement class that Luke created.
// This is so that enemies follow the same movement rules as the player does.

public class SoldierMovement : Movement
{
    // Use methods from the playerMovement class 
    public GameObject playerMovement;
    public PlayerMovement playerMovementScripts;
    
    public float[,] waypoints;
    public int direction;
    public int moveCounter = 1;
    private float speedModifier = 5;
    // A flag to show that the direction changed, only for the inspector
    public bool changeDir = false;
    // Set whether the enemy is to patrol using waypoints or move randomly
    public bool patrol = true;
    // Waypoints for patrolling
    public float waypoint1x;
    public float waypoint1y;
    public float waypoint2x;
    public float waypoint2y;
    public float waypoint3x;
    public float waypoint3y;
    public float MoveX, MoveY;
    public int currentWaypoint = 1;
    public bool enemyTurn = false;
    public static bool doneMoving = false;

    void Start()
    {
        // Enclosing the FineGameObject methods in an if statement will stop a flood of errors
        // popping up if it can't find the object. Was useful when developing and searching for errors in console.
        if (levelManager = GameObject.FindGameObjectWithTag("level0Manager"))
        {
            levelManagerScripts = levelManager.GetComponent<Level0Manager>();
        }

        if (playerMovement = GameObject.FindGameObjectWithTag("Player"))
        {
            playerMovementScripts = playerMovement.GetComponent<PlayerMovement>();
        }

        // allEnemies is inherited from Movement class
        // Creates an array of every enemy in the scene to iterate through
        allEnemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy currentEnemy in allEnemies)
        {
            enemyScripts = currentEnemy.GetComponent<Enemy>();
        }

        myRigidbody = GetComponent<Rigidbody2D>();
        
        // Set waypoint positions. The waypoints creates a three point patrol pattern that
        // the enemy will path through repeatedly. Can use for guarding a certain area.
        waypoints = new float[3, 2];
        waypoints[0,0] = getPositionX();
        waypoints[0,1] = getPositionY();
        waypoints[1,0] = getPositionX()+1;
        waypoints[1,1] = getPositionY();
        waypoints[2,0] = getPositionX()+1;
        waypoints[2,1] = getPositionY()+1;
        waypoint1x = waypoints[0, 0];
        waypoint1y = waypoints[0, 1];
        waypoint2x = waypoints[1, 0];
        waypoint2y = waypoints[1, 1];
        waypoint3x = waypoints[2, 0];
        waypoint3y = waypoints[2, 1];
        movement = enemyScripts.getMovement();

        // This obtains the last known position of the enemy.
        // It is needed in Start so that the waypoints work properly.
        // Otherwise the enemies that patrol may not move on the first turn
        // because the game assumes that they have already moved their max amount.
        oldpositionX = myRigidbody.position.x;
        oldpositionY = myRigidbody.position.y;
    }


    void FixedUpdate()
    {
        // Obtain the player's location from Player
        // The enemy needs to know how far away the player is to determine what to do
        // If the total units between the player and enemy are less than 5, the enemy will move
        // towards the player, otherwise the enemy will either patrol its waypoints or move randomly
        float playerPosX = playerMovementScripts.getPositionX();
        float playerPosY = playerMovementScripts.getPositionY();
        float currentPosX = getPositionX();
        float currentPosY = getPositionY();
        // Determine the X and Y components of the distance between the player and enemy
        float movementX = playerPosX - currentPosX;
        float movementY = playerPosY - currentPosY;
        // Obtain whose turn it is from the turnManager in level0Manager
        // false = enemy turn
        if (levelManagerScripts.turnManagerEnemy() == true)
        {
            //Debug.Log("Entered Enemy Movement Function");
            // Get the total amount the enemy has moved so far this turn
            travelledTotal = getMovement(travelledTotal);
            //Debug.Log("TravelledTotal " + travelledTotal);
            // If the enemy has moved approximately 1 unit in distance, randomly change the direction of movement
            // Also needs to calculate this on the start of the turn.
            if (((travelledTotal % 2 >= 0.95) && (travelledTotal % 2 <= 1.05) && changeDir == false) || (travelledTotal == 0) && !patrol)
            {
                //Debug.Log("Change Dir True");
                changeDir = true;
                direction = Random.Range(1, 9);
            }
            else
            {
                //Debug.Log("Change Dir False");
                changeDir = false;
            }
            // Move the unit only every 5 frames (assuming 60 fps). This is to slow down movement speed
            if (moveCounter == 5)
            {
                //Debug.Log("Movement Counter reached 5");
                // Player is more than 5 units away so move in a random direction or patrol
                if (Mathf.Pow(movementX, 2) + Mathf.Pow(movementY, 2) > 5)
                {
                    if (patrol)
                    {
                        // Calculates where to move based on current position
                        movePatrol(currentPosX, currentPosY);
                    }
                    else
                    {
                        // Update the MoveX and MoveY values
                        moveRandom(direction);
                    }
                }
                // Player is within 5 units so move towards them
                else
                {
                    // Calculates where to move based on distance between player and enemy
                    moveTowardPlayer(movementX, movementY);
                }
                // Call the actual move function with the updated MoveX and MoveY values
                moveEnemy(MoveX, MoveY);
                moveCounter = 1;
            }
            else
            {
                moveCounter++;
            }

        }
        //If not players turn, don't move
        if (levelManagerScripts.turnManagerEnemy() == false)
        {
            travelledTotal = 0;
            moveEnemy(0, 0);
        }

        //Debug.Log("TravelledTotal " + travelledTotal);
        // The enemy unit has moved more than it is allowed so it is end of turn
        if (travelledTotal >= movement)
        {
            //Debug.Log("Enemy Turn Ending");
            //Debug.Log("TravelledTotal "+ travelledTotal);
            //Debug.Log("Movement " + movement);
            levelManagerScripts.changeEnemyTurn();
            travelledTotal = 0;
        }

    }

    // moveEnemy performs the actual movement of the enemy unit
    public void moveEnemy(float directionX, float directionY)
    {
        velocity = new Vector2(speedModifier * directionX, speedModifier * directionY);
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

    // Sets MoveX and MoveY in 1 of 8 configurations representing up, down, left, right and diagonals
    private void moveRandom(int direction)
    {
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

    // Sets MoveX and MoveY based on the waypoints, current position and what stage of
    // the patrol pattern the unit is at.
    private void movePatrol(float currentPosX, float currentPosY)
    {
        // at first waypoint so move towards second waypoint
        if (currentWaypoint == 1)
        {
            // Update X movement
            if ((waypoints[currentWaypoint, 0] - currentPosX) > 0.1)
            {
                MoveX = 1;
            }
            else if ((waypoints[currentWaypoint, 0] - currentPosX) < -0.1)
            {
                MoveX = -1;
            }
            else
            {
                MoveX = 0;
            }
            // Update Y movement
            if ((waypoints[currentWaypoint, 1] - currentPosY) > 0.1)
            {
                MoveY = 1;
            }
            else if ((waypoints[currentWaypoint, 1] - currentPosY) < -0.1)
            {
                MoveY = -1;
            }
            else
            {
                MoveY = 0;
            }
        }
        // At second waypoint so move toward third waypoint
        else if (currentWaypoint == 2)
        {
            // Update X movement
            if ((waypoints[currentWaypoint, 0] - currentPosX) > 0.1)
            {
                MoveX = 1;
            }
            else if ((waypoints[currentWaypoint, 0] - currentPosX) < -0.1)
            {
                MoveX = -1;
            }
            else
            {
                MoveX = 0;
            }
            // Update Y movement
            if ((waypoints[currentWaypoint, 1] - currentPosY) > 0.1)
            {
                MoveY = 1;
            }
            else if ((waypoints[currentWaypoint, 1] - currentPosY) < -0.1)
            {
                MoveY = -1;
            }
            else
            {
                MoveY = 0;
            }
        }
        // Otherwise at third waypoint so move back to the first
        else
        {
            // Update X movement
            if ((waypoints[0, 0] - currentPosX) > 0.1)
            {
                MoveX = 1;
            }
            else if ((waypoints[0, 0] - currentPosX) < -0.1)
            {
                MoveX = -1;
            }
            else
            {
                MoveX = 0;
            }
            // Update Y movement
            if ((waypoints[0, 1] - currentPosY) > 0.1)
            {
                MoveY = 1;
            }
            else if ((waypoints[0, 1] - currentPosY) < -0.1)
            {
                MoveY = -1;
            }
            else
            {
                MoveY = 0;
            }
        }
        // Reached destination so go to next waypoint
        if (((MoveX == 0) && ((MoveY == 0))))
        {
            if (currentWaypoint < 2)
            {
                currentWaypoint++;
            }
            else
            {
                currentWaypoint = 0;
            }
        }
    }


    private void moveTowardPlayer(float movementX, float movementY)
    {
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

        if ((movementX < 0.3) && (movementY < 0.3))
        {
            MoveY = 0;
            MoveX = 0;
            travelledTotal++;
        }
    }

    // Dynamic binding of getMovement function from Movement class
    protected float getMovement(float travelledTotal)
    {
        return base.getMovement(travelledTotal);
    }

    // Ends the turn immediately upon enemy attacking
    public void attack()
    {
        //Debug.Log("Enemy Attack Function Called");
        travelledTotal = 0;
        levelManagerScripts.changeEnemyTurn();
        //travelledTotal++;
    }

    // Code EnemyTurnManager not currently working properly
    /*public bool getEnemyTurn()
    {
        if (enemyTurn == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool getEnemyDoneMoving()
    {
        if (doneMoving == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void finishMove()
    {
        doneMoving = true;
    }

    public void startTurn()
    {
        doneMoving = false;
        Debug.Log("Enemy turn started");
        enemyTurn = true;
    }

    public void endTurn()
    {
        doneMoving = true;
        Debug.Log("Enemy turn ended");
        enemyTurn = false;
    }*/

}
