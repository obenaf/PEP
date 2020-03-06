using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public int getMeleeDamage(int attack, int accuracy){//Returns a damage int based off the players attack
        int damage;
        int hitOrMiss = Random.Range(1, 100);
        
        if (hitOrMiss <= accuracy)
        {
            damage = Random.Range(1, attack);
        }
        else
        {
            damage = 0;
        }
        return damage;
    }
    


}
