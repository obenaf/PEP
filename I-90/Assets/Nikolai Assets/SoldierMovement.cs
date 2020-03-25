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
    public bool changeDir = false;
    public bool patrol = false;
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
        if (levelManagerScripts.turnManager() == false)
        {
            travelledTotal = getMovement(travelledTotal);
            if (((travelledTotal % 2 >= 0.95) && (travelledTotal % 2 <= 1.05) && changeDir == false) || (travelledTotal == 0) && !patrol)
            {
                changeDir = true;
                direction = Random.Range(1, 9);
            }
            else
            {
                //direction = Random.Range(1, 9);
                changeDir = false;
            }
            // Move only every 5 frames (assuming 60)
            if (moveCounter == 5)
            {
                // Player is more than 5 units away so move in a random direction or patrol
                if (Mathf.Pow(movementX, 2) + Mathf.Pow(movementY, 2) > 5)
                {
                    if (patrol)
                    {
                        if (currentWaypoint == 1)
                        {
                            if((waypoints[currentWaypoint, 0] - currentPosX) > 0.1)
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
                        else if (currentWaypoint == 2)
                        {
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
                        else
                        {
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
                        // Reached destination
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


                    else
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
                }
                // Player is within 5 units so move towards them
                else
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

    protected override float getMovement(float travelledTotal)
    {
        return base.getMovement(travelledTotal);
    }

}
