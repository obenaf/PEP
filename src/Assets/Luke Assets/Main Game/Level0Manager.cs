using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0Manager : MonoBehaviour
{
    GameObject player;
    PlayerMovement playerScripts;

    [SerializeField]
    public bool playerTurn;//True is player's turn, false is enemy's turn

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScripts = player.GetComponent<PlayerMovement>();

        playerTurn = true;
    }

    void Update()
    {
        
    }
    public void changeTurn(){
        playerTurn = !playerTurn;
    }
    public bool turnManager(){// gives state of combat to other scripts
        if (playerTurn == true){
            return true;
        }
        else{
            return false;
        }
    }
}


