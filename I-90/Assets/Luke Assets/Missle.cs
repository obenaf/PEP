using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : Movement
{
    private new Rigidbody2D myRigidbody;
    private new float speed = 1.0f;

    public GameObject SoldierMovement;//Used for SoldierMovement scripts
    public SoldierMovement enemyMovementScripts;
    public SoldierMovement closestEnemyMovementScripts;

    public GameObject playerMovement;
    public PlayerMovement playerMovementScripts;

    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
        allEnemies = GameObject.FindObjectsOfType<Enemy>();

        PlayerMovement = GameObject.FindGameObjectWithTag("Player");//Set playerMovement scripts to current player object
        playerMovementScripts = PlayerMovement.GetComponent<PlayerMovement>();
    }

    void FixedUpdate()
    {
        findClosestEnemy();
        closestEnemyMovementScripts = closestEnemy.GetComponent<SoldierMovement>();
        float enemyPosX = closestEnemyMovementScripts.getPositionX();
        float enemyPosY = closestEnemyMovementScripts.getPositionY();
        float currentPosX = getPositionX();
        float currentPosY = getPositionY();

        float movementX = enemyPosX - currentPosX;
        float movementY = enemyPosY - currentPosY;
        moveArrow(movementX, movementY);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }

    void moveArrow(float directionX, float directionY)
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
    public void findClosestEnemy()
    {
        foreach (Enemy currentEnemy in allEnemies)
        {
            if (currentEnemy != null)
            {
                if (closestEnemy == null)
                {
                    closestEnemy = currentEnemy;
                }
                else//determine if current enemy in loop is closer than 'closestEnemy'
                {
                    float currentPosX, currentPosY, closestPosX, closestPosY, closestTotal, currentTotal, myPositionX, myPositionY;
                    closestTotal = 0f;
                    currentTotal = 0f;
                    myPositionX = playerMovementScripts.getPositionX();
                    myPositionY = playerMovementScripts.getPositionY();


                    enemyMovementScripts = currentEnemy.GetComponent<SoldierMovement>();
                    currentPosX = enemyMovementScripts.getPositionX();
                    currentPosY = enemyMovementScripts.getPositionY();
                
                    closestEnemyMovementScripts = closestEnemy.GetComponent<SoldierMovement>();
                    closestPosX = closestEnemyMovementScripts.getPositionX();
                    closestPosY = closestEnemyMovementScripts.getPositionY();

                    closestTotal = Mathf.Sqrt(((closestPosX-myPositionX) * (closestPosX - myPositionX)) + ((closestPosY - myPositionY) * (closestPosY - myPositionY)));
                    currentTotal = Mathf.Sqrt(((currentPosX-myPositionX) * (currentPosX - myPositionX)) + ((currentPosY - myPositionY) * (currentPosY - myPositionY)));
                    Debug.Log("Closest Total is " + closestTotal);
                    Debug.Log("CurrentTotal is " + currentTotal);
                    if (currentTotal < closestTotal)
                    {
                        Debug.Log("Changing closest enemy");
                        closestEnemy = currentEnemy;
                    }
                }
            }
        }
    }
}
