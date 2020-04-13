/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementTurnManager : MonoBehaviour
{
    public GameObject levelManager;
    public SoldierMovement enemyMovementScripts;
    public Level0Manager levelManagerScripts;
    public Enemy enemyScripts;
    public Enemy closestEnemy = null;// will be used for determining closes enemy when attacking
    public Enemy[] allEnemies;
    public static EnemyMovementTurnManager _instance;
    //public bool enemyTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        if (levelManager = GameObject.FindGameObjectWithTag("level0Manager"))
        {
            levelManagerScripts = levelManager.GetComponent<Level0Manager>();
        }
        
        allEnemies = GameObject.FindObjectsOfType<Enemy>();//changed - allEnemies is inherited from Movement class
        foreach (Enemy currentEnemy in allEnemies)
        {
            enemyScripts = currentEnemy.GetComponent<Enemy>();//changed
            enemyMovementScripts = currentEnemy.GetComponent<SoldierMovement>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (levelManagerScripts.turnManagerEnemy() == true)
        {
            //Debug.Log("It's the Enemy's Turn");
            foreach (Enemy currentEnemy in allEnemies)
            {
                //Debug.Log("in foreach loop");
                if (_instance == null)
                {
                    Debug.Log("instance null");
                    //if (enemyMovementScripts.getEnemyTurn() == true)
                    //{
                    //Debug.Log("Started enemy turn");
                    
                    _instance = this;
                }
                else if ((_instance == this) && (enemyMovementScripts.getEnemyTurn() == false) )
                {
                    Debug.Log("instance not null");
                    enemyMovementScripts.startTurn();
                    if (enemyMovementScripts.getEnemyDoneMoving() == true)
                    {
                        Debug.Log("instance nulled");
                        _instance = null;
                    }
                    //else
                    //{
                    //    enemyMovementScripts.startTurn();
                    //}
                }
                //}
            }
        }
    }
}
*/