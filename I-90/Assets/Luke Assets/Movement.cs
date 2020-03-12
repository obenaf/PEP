using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject levelManager;//Call methods from the Level0Manager.cs
    public Level0Manager levelManagerScripts;

    public GameObject PlayerMovement;//Call methods from the Player.cs
    public Player playerScripts;

    public GameObject enemy;//Call methods from the Player.cs
    public Enemy enemyScripts;

    public float speed;
    public float movement, travelledX, travelledY, travelledTotal;

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

    protected virtual float getMovement(float travelledTotal)
    {
        travelledX = Mathf.Abs(myRigidbody.position.x - oldpositionX);
        travelledY = Mathf.Abs(myRigidbody.position.y - oldpositionY);
        
        oldpositionX = myRigidbody.position.x;
        oldpositionY = myRigidbody.position.y;

        return travelledY + travelledX + travelledTotal;
    }

}
