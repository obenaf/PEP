using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject attacks;//Call methods from the Level0Manager.cs
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
        attack = 2;
        movement = 2;
    }
    void Start()
    {
        attacks = GameObject.FindGameObjectWithTag("Attacks");
        attackScripts = attacks.GetComponent<Attacks>();
        
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyScripts = enemy.GetComponent<Enemy>();
    }

    
    void Update()
    {
        attackInput = Input.GetAxisRaw("Fire1");
        if (attackInput == 1){
            int damage;
            damage = attackScripts.getMeleeDamage(attack);

        }
    }

    public float getMovement(){
        return movement;
    }
}
