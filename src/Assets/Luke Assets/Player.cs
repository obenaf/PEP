using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject levelManager;//Call methods from the Level0Manager.cs
    Level0Manager levelManagerScripts;

    GameObject attackOptions;//Call methods from the Level0Manager.cs
    Attacks attackScripts;

    GameObject enemy;
    Enemy enemyScripts; 

    GameObject playerMovement;
    PlayerMovement playerMovementScripts;

    GameObject enemyMovement;
    EnemyMovement enemyMovementScripts;
    

    public int health;
    public int attack;
    public int accuracy;
    float range;
    public float movement;
    public int level;
    public int experience;
    
    
    
    
    void Awake()
    {
        health = 10;
        attack = 5;
        accuracy = 50;
        movement = 1000;
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
        attackInput = Input.GetAxisRaw("Fire1");

        if (levelManagerScripts.turnManager() == true){
            if (attackInput == 1){
                if (attackPossible(range) == true){
                    int damage;
                    damage = attackScripts.getMeleeDamage(attack, accuracy);
                    enemyScripts.damageEnemy(damage);
                }
            }
        }
    }

    public float getMovement(){
        return movement;
    }
    public bool attackPossible(float range){
        float enemyX, enemyY, playerX, playerY;
        playerX = playerMovementScripts.getPositionX();
        playerY = playerMovementScripts.getPositionY();
        enemyX = enemyMovementScripts.getPositionX();
        enemyY = enemyMovementScripts.getPositionY();

        float a, b, c; //pythagorean variables
        a = Mathf.Abs(playerX - enemyX);
        b = Mathf.Abs(playerY - enemyY);
        c = Mathf.Sqrt((a*a)+(b*b));

        if(c <= range){
            return true;
        }
        else{
            return false;
        }
    }
    public void gainExperience(int newExp)
    {
        experience = experience + newExp;
    }
    public void gainLevel()
    {

    }
}
