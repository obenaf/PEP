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

    public int getMeleeDamage(int attack, int accuracy){//Returns a damage int based off the players attack and accuracy
        int damage;
        int hitOrMiss = Random.Range(1, 100);
        
        if (hitOrMiss <= accuracy)
        {
            damage = Random.Range(1, attack);
            Debug.Log("Melee Attack Hit");
        }
        else
        {
            damage = 0;
            Debug.Log("Melee Attack Missed");
        }
        return damage;
    }
    public int getRangeDamage(int attack, int accuracy)
    {
        int damage;
        int hitOrMiss = Random.Range(1, 100);

        if (hitOrMiss <= accuracy)
        {
            damage = Random.Range(1, attack);
            Debug.Log("Ranged Attack Hit");
        }
        else
        {
            damage = 0;
            Debug.Log("Ranged Attack Missed");
        }
        return damage;
    }
    public void spawnArrow() // Spawns arrow at player's current position. Needs to be updated to be able to spawn arrow at enemy's position as well
    {
        GameObject a = Instantiate(ArrowPrefab) as GameObject;
        a.transform.position = new Vector2(playerMovementScripts.getPositionX(), playerMovementScripts.getPositionY());
    }

}
