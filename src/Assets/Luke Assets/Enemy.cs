using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int health;
    public int attack;
    public float movement = 3;
    void Awake()
    {
        health = 10;
        attack = 2;
        movement = 3;
    }
    void Start()
    {

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
