using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack : Enemy {
    public Player playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("level0Manager");
        levelManagerScripts = levelManager.GetComponent<Level0Manager>();

        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        //SoldierMovement = GameObject.FindGameObjectWithTag("Enemy");

        playerMovement = GameObject.FindGameObjectWithTag("Player");
        playerMovementScripts = playerMovement.GetComponent<PlayerMovement>();
        playerScripts = playerMovement.GetComponent<Player>();

        enemyMovementScripts = gameObject.GetComponent<SoldierMovement>();
        //enemyScripts = enemy.GetComponent<Enemy>();


        attackOptions = GameObject.FindGameObjectWithTag("Attacks");
        attackScripts = attackOptions.GetComponent<Attacks>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (levelManagerScripts.turnManager() == false)
        {
            if (attackPossible(range) == true)
            {
                //int damage;
                levelManagerScripts.changeTurn();
                //damage = attackScripts.getMeleeDamage(attack, accuracy);
                Debug.Log("attacking player");
                attackPlayer();
                
                
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

    protected override void attackPlayer(){
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
