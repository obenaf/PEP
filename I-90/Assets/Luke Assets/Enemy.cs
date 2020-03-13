using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    void Awake()
    {
        health = 10;
        attack = 2;
        movement = 1;
        experience = 10;
    }
    void Start()
    {
        //Set variables to current Player object
        player = GameObject.FindGameObjectWithTag("Player");
        playerScripts = player.GetComponent<Player>();
    }

   
    void FixedUpdate()
    {
        if (health <= 0)
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
        health = health - damage;
    }
}
