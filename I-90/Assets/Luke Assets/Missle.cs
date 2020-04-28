using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : Movement
{
    private static Missle uniqueInstance;
    private Missle(){}
    public static Missle getInstance(){
        Debug.Log("Creating Missle");
        if (uniqueInstance == null){
            //Debug.Log("unique instance is null");
            uniqueInstance = new Missle();
        }
        else{
            //Debug.Log("unique instance is not null");
        }
        
        return uniqueInstance;
    }

    public GameObject SoldierMovement;//Used for SoldierMovement scripts
    public SoldierMovement enemyMovementScripts;
    public SoldierMovement closestEnemyMovementScripts;

    public GameObject playerMovement;
    public PlayerMovement playerMovementScripts;

    public GameObject attackOptions;//Call methods from the Level0Manager.cs
    public Attacks attackScripts;

    public bool succesfulHit;

    float movementX, movementY;

    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
        allEnemies = GameObject.FindObjectsOfType<Enemy>();

        PlayerMovement = GameObject.FindGameObjectWithTag("Player");//Set playerMovement scripts to current player object
        playerMovementScripts = PlayerMovement.GetComponent<PlayerMovement>();

        levelManager = GameObject.FindGameObjectWithTag("level0Manager");
        levelManagerScripts = levelManager.GetComponent<Level0Manager>();

        attackOptions = GameObject.FindGameObjectWithTag("Attacks");
        attackScripts = attackOptions.GetComponent<Attacks>();
        
        succesfulHit = false;

    }

    void FixedUpdate()
    {
        findClosestEnemy();
        closestEnemyMovementScripts = closestEnemy.GetComponent<SoldierMovement>();
        float enemyPosX = closestEnemyMovementScripts.getPositionX();
        float enemyPosY = closestEnemyMovementScripts.getPositionY();
        float currentPosX = getPositionX();
        float currentPosY = getPositionY();

        movementX = enemyPosX - currentPosX;
        movementY = enemyPosY - currentPosY;
        if (succesfulHit == false){
            moveArrow(movementX, movementY);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
        }
        else if(col.gameObject.tag == "Enemy"){
            gameObject.transform.position = new Vector2(10000,10000);
            succesfulHit = true;
        }
        else
        {
            Destroy(gameObject);   
            //levelManagerScripts.changeTurn();     
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
    public bool wasHitSuccesful()
    {
        if (succesfulHit == true){
            levelManagerScripts.changeTurn();
        }
        bool hit = false;
        hit = succesfulHit;
        succesfulHit = false;
        return hit;        
        Destroy(gameObject);
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
                    
                    if (currentTotal < closestTotal)
                    {
                        
                        closestEnemy = currentEnemy;
                    }
                }
            }
        }
    }
}
