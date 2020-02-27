using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject levelManager;//Call methods from the Level0Manager.cs
    Level0Manager levelManagerScripts;

    GameObject enemy;//Call methods from the Player.cs
    Enemy enemyScripts;

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
        
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyScripts = enemy.GetComponent<Enemy>();
        
        myRigidbody = GetComponent<Rigidbody2D>();
        movement = enemyScripts.getMovement();
    }


    void Update()
    {
        float enemyMoveX, enemyMoveY;
        
        if (levelManagerScripts.turnManager() == false)
        {
                enemyMoveX = Input.GetAxisRaw("Horizontal");
                enemyMoveY = Input.GetAxisRaw("Vertical");
                moveEnemy(enemyMoveX, enemyMoveY);
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
    void moveEnemy(float directionX, float directionY)
    {
            velocity = new Vector2(directionX, directionY);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
