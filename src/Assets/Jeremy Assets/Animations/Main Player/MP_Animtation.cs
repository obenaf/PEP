using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Animtation : MonoBehaviour
{
    private Animator Mainanim;//animation variable for the name of the animator
    // Start is called before the first frame update
    void Start()
    {
        Mainanim = GetComponent<Animator>();//set the variable to the name of the animator controller

    }

    // Update is called once per frame
    void Update()
    {
        Mainanim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));//sets the MoveX for animation
        Mainanim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));//sets the MoveX for animation
    }
}
