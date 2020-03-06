using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{

    public GameObject ArrowPrefab;
    public GameObject playerMovement;
    public PlayerMovement playerMovementScripts;

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player");
        playerMovementScripts = playerMovement.GetComponent<PlayerMovement>();
    }

    
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
    public int getRangeDamage(int attack, int accuracy)
    {
        return 0;
    }
    public void spawnArrow()
    {
        GameObject a = Instantiate(ArrowPrefab) as GameObject;
        a.transform.position = new Vector2(playerMovementScripts.getPositionX(), playerMovementScripts.getPositionY());
    }

}
