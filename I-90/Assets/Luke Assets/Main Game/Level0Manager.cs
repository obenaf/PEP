using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0Manager : MonoBehaviour
{
    //GameObject player;
    //PlayerMovement playerScripts;

    [SerializeField]
    public bool playerTurn = true;//True is player's turn, false is enemy's turn

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
    public void changeTurn(){//Allows objects to change the turn
        
        playerTurn = !playerTurn;
    }
    public bool turnManager(){//Gives state of combat to other scripts
        if (playerTurn == true){
            return true;
        }
        else{
            return false;
        }
    }
}


