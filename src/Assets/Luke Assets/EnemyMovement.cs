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
        float MoveX, MoveY;
        
        if (levelManagerScripts.turnManager() == false)
        {
                MoveX = Input.GetAxisRaw("Horizontal");
                MoveY = Input.GetAxisRaw("Vertical");
                moveEnemy(MoveX, MoveY);
        }
        if (levelManagerScripts.turnManager() == true)//If not players turn, don't move. This prevents other characters from pushing this character
        {
            moveEnemy(0, 0);
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

    public float getPositionX(){
        float myPositionX = myRigidbody.position.x;
        return myPositionX;
    }

    public float getPositionY(){
        float myPositionY = myRigidbody.position.y;
        return myPositionY;
    }
}
