using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : Movement
{
    public GameObject playerMovement;
    public PlayerMovement playerMovementScripts;
    public float[,] waypoints;
    public int direction;
    public int moveCounter = 1;
    private float speedModifier = 2;
    // A flag to show that the direction changed, only for the inspector
    public bool changeDir = false;
    // Set whether the enemy is to patrol or move randomly
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
    }


    void FixedUpdate()
    {
        //float MoveX, MoveY;

        float playerPosX = playerMovementScripts.getPositionX();
        float playerPosY = playerMovementScripts.getPositionY();
        float currentPosX = getPositionX();
        float currentPosY = getPositionY();
        float movementX = playerPosX - currentPosX;
        float movementY = playerPosY - currentPosY;
        // false = enemy turn
        if (levelManagerScripts.turnManager() == false)
        {
            // Get the total amount the enemy has moved so far this turn
            travelledTotal = getMovement(travelledTotal);
            // Set the direction for the enemy to move via moveRandom, approx every 1 unit, potentially change it
            if (((travelledTotal % 2 >= 0.95) && (travelledTotal % 2 <= 1.05) && changeDir == false) || (travelledTotal == 0) && !patrol)
            {
                changeDir = true;
                direction = Random.Range(1, 9);
            }
            else
            {
                changeDir = false;
            }
            // Move only every 5 frames (assuming 60 fps)
            if (moveCounter == 5)
            {
                // Player is more than 5 units away so move in a random direction or patrol
                if (Mathf.Pow(movementX, 2) + Mathf.Pow(movementY, 2) > 5)
                {
                    if (patrol)
                    {
                        movePatrol(currentPosX, currentPosY);
                    }
                    else
                    {
                        moveRandom(direction);
                    }
                }
                // Player is within 5 units so move towards them
                else
                {
                    moveTowardPlayer(movementX, movementY);
                }
                moveEnemy(MoveX, MoveY);
                moveCounter = 1;
            }
            else
            {
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
            //moveSelected = false;
            travelledTotal = 0;
        }

    }

    void moveEnemy(float directionX, float directionY)
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

    protected override float getMovement(float travelledTotal)
    {
        return base.getMovement(travelledTotal);
    }

}
