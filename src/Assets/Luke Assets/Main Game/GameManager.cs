using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool combatState;//True is in combat, false is out of combat
    void Start()
    {
        combatState = false;
    }

    void Update()
    {
        
    }
    bool inCombat(){// gives state of combat to other scripts
        if (combatState == true){
            return true;
        }
        else{
            return false;
        }
}
}


