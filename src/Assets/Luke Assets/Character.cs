using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    public GameObject levelManager;//Call methods from the Level0Manager.cs
    public Level0Manager levelManagerScripts;

    public GameObject attackOptions;//Call methods from the Level0Manager.cs
    public Attacks attackScripts;

    public GameObject enemy;
    public Enemy enemyScripts;

    public GameObject playerMovement;
    public PlayerMovement playerMovementScripts;

    public GameObject enemyMovement;
    public EnemyMovement enemyMovementScripts;

    public GameObject player;//Call methods from the Player.cs
    public Player playerScripts;

    [SerializeField]
    public int health;
    public int attack;
    public int accuracy;
    public float range;
    public float movement;
    public int level;
    public int experience;




    void Start()
    {
 
    }


    void Update()
    {
        
    }

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
