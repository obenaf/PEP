using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Animtation : MonoBehaviour
{
    private Animator Mainanim;//animation variable for the name of the animator
    public GameObject levelManager;//Call methods from the Level0Manager.cs
    public Level0Manager levelManagerScripts;

   
    // Start is called before the first frame update
    void Start()
    {
        Mainanim = GetComponent<Animator>();//set the variable to the name of the animator controller
        levelManager = GameObject.FindGameObjectWithTag("level0Manager");
        levelManagerScripts = levelManager.GetComponent<Level0Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (levelManagerScripts.turnManager() == true)//Check if it is player turn
        {
            Mainanim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));//sets the MoveX for animation
            Mainanim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));//sets the MoveX for animation
            Mainanim.SetFloat("Attack", Input.GetAxisRaw("Fire1"));//sets the MoveX for animation

        }
    }
    public void Reset()
    {
        Mainanim.SetFloat("MoveX",0);//stops movement
        Mainanim.SetFloat("MoveY",0);//sets the MoveX for animation
        Mainanim.SetFloat("Attack",0);//sets the MoveX for animation
    }
}
