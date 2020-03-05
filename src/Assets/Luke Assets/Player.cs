using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    
    
    void Awake()
    {
        maxHealth = 10;
        attack = 5;
        accuracy = 50;
        movement = 5;
        range = 1;
        rangedAttack = true;
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

        SoldierMovement = GameObject.FindGameObjectWithTag("Enemy");
        enemyMovementScripts = SoldierMovement.GetComponent<SoldierMovement>();

        currentHealth = maxHealth;
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
     public void damagePlayer(int damage){
        currentHealth = currentHealth - damage;
    }
    public int getCurrentHealth(){
        return currentHealth;
    }
}
