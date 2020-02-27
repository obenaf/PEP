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
    

    public int health;
    public int attack;
    public float movement;
    
    private float attackInput;
    
    
    void Awake()
    {
        health = 10;
        attack = 1;
        movement = 2;
    }
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("level0Manager");
        levelManagerScripts = levelManager.GetComponent<Level0Manager>();

        attackOptions = GameObject.FindGameObjectWithTag("Attacks");
        attackScripts = attackOptions.GetComponent<Attacks>();
        
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyScripts = enemy.GetComponent<Enemy>();
    }

    
    void Update()
    {
        
        attackInput = Input.GetAxisRaw("Fire1");
        if (levelManagerScripts.turnManager() == true){
            if (attackInput == 1){
                int damage;
                damage = attackScripts.getMeleeDamage(attack);
                enemyScripts.damageEnemy(damage);
                levelManagerScripts.changeTurn();
            }
        }
    }

    public float getMovement(){
        return movement;
    }
}
