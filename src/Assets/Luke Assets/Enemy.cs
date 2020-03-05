using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    void Awake()
    {
        maxHealth = 10;
        attack = 2;
        movement = 1;
        experience = 10;
    }
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScripts = player.GetComponent<Player>();
    }

   
    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            playerScripts.gainExperience(experience);
        }
    }
    public float getMovement(){
        return movement;
    }
    public void damageEnemy(int damage){
        currentHealth = currentHealth - damage;
    }
    public int getCurrentHealth(){
        return currentHealth;
    }
}
