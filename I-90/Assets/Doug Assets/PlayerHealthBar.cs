using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Modified from how to make a health bar from: https://www.youtube.com/watch?v=CA2snUe7ARM
// Adds health bars to characters that spwan (watch later): https://www.youtube.com/watch?v=kQqqo_9FfsU
public class PlayerHealthBar : MonoBehaviour
{
    public Player _Player;
    public Image foregroundImage;
    float Health;

    // Start is called before the first frame update
    void Awake()
    {
        //Health = _Player.getHealth();
        //foregroundImage.fillAmount = Health / 20f;
        //Debug.Log(Health.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        HealthFill();
    }

    public void HealthFill()
    {
        Health = _Player.getHealth();
        foregroundImage.fillAmount = Health / 2002f;
        Debug.Log(Health.ToString());

    }
}
