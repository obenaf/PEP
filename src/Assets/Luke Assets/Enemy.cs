﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health;
    int attack;
    float movement;
    void Start()
    {
        movement = 2;
    }

   
    void Update()
    {
        
    }
    public float getMovement(){
        return movement;
    }
}
