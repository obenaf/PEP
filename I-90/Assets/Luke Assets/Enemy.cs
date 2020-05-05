using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public bool allowAttack = true;
    void Awake()
    {
        //maxHealth = 10;
       // attack = 1;
        movement = 3;
        range = 0.7f;
        experience = 10;
        //accuracy = 50;
    }
    void Start()
    {
        //Set variables to current Player object
        if (player = GameObject.FindGameObjectWithTag("Player"))
        {
            playerScripts = player.GetComponent<Player>();
        }
        

        if (attackOptions = GameObject.FindGameObjectWithTag("Attacks"))
        {
            attackScripts = attackOptions.GetComponent<Attacks>();
        }
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

    }

   
    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            //Move death results to seperate function
            Destroy(gameObject);
            playerScripts.gainExperience(experience);
            playerScripts.findEnemies();
        }
        if (levelManagerScripts.turnManagerEnemy() == true)
        {
            // Check if the enemy is in attack range of the player and attacks if so
            if (attackPossible(range) == true && allowAttack == true)
            {
                allowAttack = false;
                //int damage;
                enemyMovementScripts.attack();
                //levelManagerScripts.changeEnemyTurn();
                //Debug.Log("Player Attacked");
                //damage = attackScripts.getMeleeDamage(attack, accuracy);
                //Debug.Log("attacking player");
                attackPlayer();
                //enemyMovementScripts.finishMove();
                //enemyMovementScripts.endTurn();
                StartCoroutine(changeAllowAttack());   
            }
        }
    }
    public float getMovement(){
        return movement;
    }
    public void damageEnemy(int damage){//Other objects can call this to lower this enemies health
        currentHealth = currentHealth - damage;
        //Debug.Log("Enemy Damaged");
    }
    public int getHealth()
    {
        return currentHealth;
    }
    public int getMaxHealth()
    {
        return maxHealth;
    }


    protected virtual void attackPlayer()
    {
        int damage;
        damage = attackScripts.getMeleeDamage(attack, accuracy);
        //Debug.Log("Enemy attack is "+ attack);
        playerScripts.damagePlayer(damage);
    }
    protected override bool attackPossible(float range)
    {
        return base.attackPossible(range);
    }
    IEnumerator changeAllowAttack(){
        yield return new WaitForSeconds(1);
        allowAttack = true;
        //Debug.Log("Changed allowAttack");
    }

}
