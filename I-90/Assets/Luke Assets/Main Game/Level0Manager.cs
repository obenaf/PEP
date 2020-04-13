using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0Manager : MonoBehaviour
{
    //GameObject player;
    //PlayerMovement playerScripts;

    [SerializeField]
    public bool playerTurn = true;//True is player's turn, false is enemy's turn
    public bool enemyTurn = false;

    void Awake()
    {
        
    }

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerScripts = player.GetComponent<PlayerMovement>();

    }

    void FixedUpdate()
    {
        
    }
    public void changeTurn()//Allows objects to change the turn   
    {
        playerTurn = false;
        enemyTurn = true;
        Debug.Log("Ended Player turn");
    }
    public void changeEnemyTurn()
    {
        enemyTurn = false;
        playerTurn = true;
        Debug.Log("Ended Enemy Turn");
    }

    public bool turnManager(){//Gives state of combat to other scripts
        if (playerTurn == true){
            return true;
        }
        else{
            return false;
        }
    }
    public bool turnManagerEnemy(){//Gives state of combat to other scripts
        if (enemyTurn == true){
            return true;
        }
        else{
            return false;
        }
    }
}


