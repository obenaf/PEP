using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public bool PlayerTurn;
    public float movement, travelledX, travelledY, travelledtotal;
    public float moveX, moveY, changeTurn;

    private Rigidbody2D myRigidbody;
    private Vector2 velocity;
    private float oldpositionX, oldpositionY;
    private Animator Mainanim;//animation variable for the name of the animator
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        PlayerTurn = true;
        movement = 3f;
        Mainanim = GetComponent<Animator>();//set the variable to the name of the animator controller
    }


    void Update()
    {
        changeTurn = Input.GetAxisRaw("ChangeTurn");
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        if (PlayerTurn == true)
        {
                movePlayer(moveX, moveY);
        }
        if (changeTurn == 1)
        {
            PlayerTurn = true;
        }

        travelledX = Mathf.Abs(myRigidbody.position.x - oldpositionX);
        travelledY = Mathf.Abs(myRigidbody.position.y - oldpositionY);
        travelledtotal = travelledY + travelledX + travelledtotal;
        if (travelledtotal >= movement){
            PlayerTurn = false;
            travelledtotal = 0;
        }

        oldpositionX = myRigidbody.position.x;
        oldpositionY = myRigidbody.position.y;

        Mainanim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));//sets the MoveX for animation
        Mainanim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));//sets the MoveX for animation

    }
    
    void movePlayer(float directionX, float directionY)
    {
            velocity = new Vector2(directionX, directionY);
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}