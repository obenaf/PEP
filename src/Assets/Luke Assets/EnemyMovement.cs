using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("level0Manager");
        levelManagerScripts = levelManager.GetComponent<Level0Manager>();
        
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyScripts = enemy.GetComponent<Enemy>();
        
        myRigidbody = GetComponent<Rigidbody2D>();
        movement = enemyScripts.getMovement();
    }


    void FixedUpdate()
    {
        
        if (levelManagerScripts.turnManager() == true)//If not players turn, don't move. This prevents other characters from pushing this character
        {
            moveEnemy(0, 0);
        }

        travelledTotal = getMovement(travelledTotal);

        if (travelledTotal >= movement){
            levelManagerScripts.changeTurn();
            travelledTotal = 0;
        }

    }
    
    void moveEnemy(float directionX, float directionY)
    {
            velocity = new Vector2(directionX, directionY);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }

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
