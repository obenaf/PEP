using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int attack;
    public float movement;
    void Start()
    {
        health = 10;
        attack = 2;
        movement = 2;
    }

   
    void Update()
    {
        
    }
    public float getMovement(){
        return movement;
    }
    public void damageEnemy(int damage){
        health = health - damage;
    }
}
