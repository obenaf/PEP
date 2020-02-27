using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 3.0f;
    public bool EnemyTurn;
    public int direction = 1;
    public float movement, travelledX, travelledY, travelledtotal;
    public float moveX, moveY, changeTurn;

    private Rigidbody2D myRigidbody;
    private Vector2 velocity;
    private float oldpositionX, oldpositionY;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        EnemyTurn = true;
        //movement = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        changeTurn = Input.GetAxisRaw("ChangeTurn");
        
        if (EnemyTurn == true)
        {
            direction = Random.Range(1, 5);
            if (direction == 1)
            {
                // Move Right
                moveX = 1;
                moveY = 0;

            }
            else if (direction == 2)
            {
                // Move Up
                moveX = 0;
                moveY = 1;
            }
            else if (direction == 3)
            {
                // Move Left
                moveX = -1;
                moveY = 0;
            }
            else
            {
                moveX = 0;
                moveY = -1;
            }
        }
            if (EnemyTurn == true)
            {
                moveEnemy(moveX, moveY);
            }
            if (changeTurn == 1)
            {
                EnemyTurn = true;
            }
        

        travelledX = Mathf.Abs(myRigidbody.position.x - oldpositionX);
        travelledY = Mathf.Abs(myRigidbody.position.y - oldpositionY);
        travelledtotal = travelledY + travelledX + travelledtotal;
        if (travelledtotal >= movement)
        {
            EnemyTurn = false;
            travelledtotal = 0;
        }

        oldpositionX = myRigidbody.position.x;
        oldpositionY = myRigidbody.position.y;

    }

    void moveEnemy(float directionX, float directionY)
    {
        velocity = new Vector2(directionX, directionY);
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
