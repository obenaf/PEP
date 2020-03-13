using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : Movement
{
    //public GameObject PlayerMovement;
    public GameObject playerMovement;
    public PlayerMovement playerMovementScripts;
    //private NavMeshAgent _nav;
    public int direction;
    private int moveCounter = 1;
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

            if (moveCounter == 5)
            {
                if (Mathf.Pow(movementX, 2) + Mathf.Pow(movementY, 2) > 5)
                {
                    //changeTurn = Input.GetAxisRaw("ChangeTurn");
                    direction = Random.Range(1, 5);

                    if (direction == 1)
                    {
                        // Move Right
                        MoveX = 1;
                        MoveY = 0;

                    }
                    else if (direction == 2)
                    {
                        // Move Up
                        MoveX = 0;
                        MoveY = 1;
                    }
                    else if (direction == 3)
                    {
                        // Move Left
                        MoveX = -1;
                        MoveY = 0;
                    }
                    else
                    {
                        MoveX = 0;
                        MoveY = -1;
                    }
                }
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

        travelledTotal = getMovement(travelledTotal);

        if (travelledTotal >= movement)
        {
            levelManagerScripts.changeTurn();
            travelledTotal = 0;
        }

    }

    void moveEnemy(float directionX, float directionY)
    {
        velocity = new Vector2(directionX, directionY);
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
