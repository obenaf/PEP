using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    void Awake()
    {
        maxHealth = 10;
        attack = 1;
        movement = 3;
        range = 0.7f;
        experience = 10;
        accuracy = 50;
    }
    void Start()
    {
        //Set variables to current Player object
        if (player = GameObject.FindGameObjectWithTag("Player"))
        {
            playerScripts = player.GetComponent<Player>();
        }
        currentHealth = maxHealth;

        if (attackOptions = GameObject.FindGameObjectWithTag("Attacks"))
        {
            attackScripts = attackOptions.GetComponent<Attacks>();
        }
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
    }
    public float getMovement(){
        return movement;
    }
    public void damageEnemy(int damage){//Other objects can call this to lower this enemies health
        currentHealth = currentHealth - damage;
        Debug.Log("Enemy Damaged");
    }
    public int getHealth()
    {
        return currentHealth;
    }

    protected virtual void attackPlayer()
    {
        int damage;
        damage = attackScripts.getMeleeDamage(attack, accuracy);
        playerScripts.damagePlayer(damage);
    }
    protected override bool attackPossible(float range)
    {
        return base.attackPossible(range);
    }

}
