using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : Movement
{
    private new Rigidbody2D myRigidbody;
    public new float speed = 1.0f;

    public GameObject SoldierMovement;//Used for SoldierMovement scripts
    public SoldierMovement enemyMovementScripts;

    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
        allEnemies = GameObject.FindObjectsOfType<Enemy>();
        findClosestEnemy();
        
    }

    void FixedUpdate()
    {
        enemyScripts = closestEnemy.GetComponent<Enemy>();
        enemyMovementScripts = closestEnemy.GetComponent<SoldierMovement>();
        float enemyPosX = enemyMovementScripts.getPositionX();
        float enemyPosY = enemyMovementScripts.getPositionY();
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
                    float currentPosX, currentPosY, closestPosX, closestPosY, closestTotal, currentTotal;

                    enemyScripts = currentEnemy.GetComponent<Enemy>();
                    enemyMovementScripts = currentEnemy.GetComponent<SoldierMovement>();
                    currentPosX = enemyMovementScripts.getPositionX();
                    currentPosY = enemyMovementScripts.getPositionY();

                    enemyScripts = closestEnemy.GetComponent<Enemy>();
                    enemyMovementScripts = closestEnemy.GetComponent<SoldierMovement>();
                    closestPosX = enemyMovementScripts.getPositionX();
                    closestPosY = enemyMovementScripts.getPositionY();

                    closestTotal = Mathf.Sqrt((closestPosX * closestPosX) + (closestPosY * closestPosY));
                    currentTotal = Mathf.Sqrt((currentPosX * currentPosX) + (currentPosY * currentPosY));

                    if (currentTotal <= closestTotal)
                    {
                        Debug.Log("Changing closest enemy");
                        closestEnemy = currentEnemy;
                    }
                }
            }
        }
    }
}
