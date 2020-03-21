using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack : Enemy {
    public Player playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("level0Manager");
        levelManagerScripts = levelManager.GetComponent<Level0Manager>();

        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        SoldierMovement = GameObject.FindGameObjectWithTag("Enemy");

        playerMovement = GameObject.FindGameObjectWithTag("Player");
        playerMovementScripts = playerMovement.GetComponent<PlayerMovement>();
        playerAttack = playerMovement.GetComponent<Player>();

        //enemyMovementScripts = enemy.GetComponent<SoldierMovement>();
        //enemyScripts = enemy.GetComponent<Enemy>();

        attackOptions = GameObject.FindGameObjectWithTag("Attacks");
        attackScripts = attackOptions.GetComponent<Attacks>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (levelManagerScripts.turnManager() == false)
        {
            if (attackPossible(range) == true)
            {
                int damage;
                damage = attackScripts.getMeleeDamage(attack, accuracy);
                playerAttack.damagePlayer(damage);
                levelManagerScripts.changeTurn();
            }
        }
    }

    protected override bool attackPossible(float range)
    {
        return base.attackPossible(range);
    }

    /*public void attackPlayer() { 
        if (levelManagerScripts.turnManager() == true)
        {
            if (attackPossible(range) == true)
            {
                int damage;
                damage = attackScripts.getMeleeDamage(attack, accuracy);
                playerAttack.damagePlayer(damage);
                //levelManagerScripts.changeTurn();
            }
        }
    }*/
}
