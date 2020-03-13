using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject levelManager;//Call methods from the Level0Manager.cs
    public Level0Manager levelManagerScripts;

    public GameObject PlayerMovement;//Call methods from the Player.cs
    public Player playerScripts;

    public Enemy enemyScripts;
    public Enemy closestEnemy = null;// will be used for determining closes enemy when attacking
    public Enemy[] allEnemies;

    public float speed;// Movement speed of all characters for animation purposes. Does not have to do with game related attributes
    public float movement, travelledTotal;

    public Rigidbody2D myRigidbody;
    public Vector2 velocity;
    public float oldpositionX, oldpositionY;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Calculate movement of objects each frame
    protected virtual float getMovement(float travelledTotal)
    {
        float travelledX, travelledY;
        travelledX = Mathf.Abs(myRigidbody.position.x - oldpositionX);
        travelledY = Mathf.Abs(myRigidbody.position.y - oldpositionY);
        
        oldpositionX = myRigidbody.position.x;
        oldpositionY = myRigidbody.position.y;

        return travelledY + travelledX + travelledTotal;
    }

}
