using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    public GameObject levelManager;//Call methods from the Level0Manager.cs
    public Level0Manager levelManagerScripts;

    public GameObject attackOptions;//Call methods from the Level0Manager.cs
    public Attacks attackScripts;


    public GameObject playerMovement;//Used for PlayerMovement scripts
    public PlayerMovement playerMovementScripts;

    public GameObject SoldierMovement;//Used for SoldierMovement scripts
    public SoldierMovement enemyMovementScripts;

    public GameObject player;//Call methods from the Player.cs
    public Player playerScripts;

    public Enemy closestEnemy = null;
    public Enemy[] allEnemies;// There will be multiple Emeny Objects at any time. This array will be used to store all the objects at any given point
    public Enemy enemyScripts;



    [SerializeField]
    public int health;
    public int attack;
    public int accuracy;
    public int armor;
    public float range;//Valid attack range
    public float movement;//Allowed movement per turn
    public int level;
    public int experience;
    public bool isRanged;// Will be used to differentiate between melee and ranged attacks




    void Start()
    {
 
    }


    void Update()
    {
        
    }

    //Calculates distance between the player and the enemy to determine if an attack is possible
    protected virtual bool attackPossible(float range)
    {
        float enemyX, enemyY, playerX, playerY;
        playerX = playerMovementScripts.getPositionX();
        playerY = playerMovementScripts.getPositionY();
        enemyX = enemyMovementScripts.getPositionX();
        enemyY = enemyMovementScripts.getPositionY();

        float a, b, c; //pythagorean variables
        a = Mathf.Abs(playerX - enemyX);
        b = Mathf.Abs(playerY - enemyY);
        c = Mathf.Sqrt((a * a) + (b * b));

        if (c <= range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
