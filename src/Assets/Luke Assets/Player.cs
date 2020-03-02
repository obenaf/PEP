﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    
    
    void Awake()
    {
        health = 10;
        attack = 5;
        accuracy = 50;
        movement = 5;
        range = 1;
    }
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("level0Manager");
        levelManagerScripts = levelManager.GetComponent<Level0Manager>();

        attackOptions = GameObject.FindGameObjectWithTag("Attacks");
        attackScripts = attackOptions.GetComponent<Attacks>();
        
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyScripts = enemy.GetComponent<Enemy>();

        playerMovement = GameObject.FindGameObjectWithTag("Player");
        playerMovementScripts = playerMovement.GetComponent<PlayerMovement>();

        enemyMovement = GameObject.FindGameObjectWithTag("Enemy");
        enemyMovementScripts = enemyMovement.GetComponent<EnemyMovement>();
    }

    
    void FixedUpdate()
    {
        float attackInput;

        if (levelManagerScripts.turnManager() == true){
            attackInput = Input.GetAxisRaw("Fire1");
            if (attackInput == 1){
                if (attackPossible(range) == true){
                    int damage;
                    damage = attackScripts.getMeleeDamage(attack, accuracy);
                    enemyScripts.damageEnemy(damage);
                    attackInput = 0;
                    levelManagerScripts.changeTurn();
                }
            }
        }
    }

    public float getMovement(){
        return movement;
    }
    protected override bool attackPossible(float range){
        return base.attackPossible(range);
    
    }
    public void gainExperience(int newExp)
    {
        experience = experience + newExp;
    }
    public void gainLevel()
    {

    }
}
