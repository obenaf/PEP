using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SoldierAttack handles attacking of the player for all enemies
public class SoldierAttack : Enemy
{
    public Player playerAttack;
    void Awake()
    {
        /*maxHealth = 10;
        currentHealth = 10;
        attack = 2;
        movement = 3;
        range = 0.7f;
        experience = 10;
        accuracy = 50;*/
    }
    // Start is called before the first frame update
    void Start()
    {
        // Enclosing the FineGameObject methods in an if statement will stop a flood of errors
        // popping up if it can't find the object. Was useful when developing and searching for errors in console.
        if (levelManager = GameObject.FindGameObjectWithTag("level0Manager"))
        {
            levelManagerScripts = levelManager.GetComponent<Level0Manager>();
        }

        if (playerMovement = GameObject.FindGameObjectWithTag("Player"))
        {
            playerMovementScripts = playerMovement.GetComponent<PlayerMovement>();
            playerScripts = playerMovement.GetComponent<Player>();
        }

        enemyMovementScripts = gameObject.GetComponent<SoldierMovement>();
        //enemyScripts = enemy.GetComponent<Enemy>();


        if (attackOptions = GameObject.FindGameObjectWithTag("Attacks"))
        {
            attackScripts = attackOptions.GetComponent<Attacks>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Checks if it is the enemy's turn
        if (levelManagerScripts.turnManagerEnemy() == true)
        {
            // Check if the enemy is in attack range of the player and attacks if so
            if (attackPossible(range) == true)
            {
                //int damage;
                enemyMovementScripts.attack();
                //levelManagerScripts.changeEnemyTurn();
                //Debug.Log("Player Attacked");
                //damage = attackScripts.getMeleeDamage(attack, accuracy);
                //Debug.Log("attacking player");
                attackPlayer();
                //enemyMovementScripts.finishMove();
                //enemyMovementScripts.endTurn();
            }
        }
    }

    protected override bool attackPossible(float range)
    {
        /*float enemyX, enemyY, playerX, playerY;
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
        }*/
        //return GameObject.attackPossible();
        return base.attackPossible(range);
    }

    protected override void attackPlayer()
    {
        base.attackPlayer();
    }

    /*public void attackPlayer() { 
        if (levelManagerScripts.turnManager() == true)
        {
            if (attackPossible(range) == true)
            {
                int damage;
                damage = attackScripts.getMeleeDamage(attack, accuracy);
                playerAttack.damagePlayer(damage);
                //levelManagerScripts.changeTurn();
            }
        }
    }*/
}
