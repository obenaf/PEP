using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Modified from how to make a health bar at: https://www.youtube.com/watch?v=CA2snUe7ARM
// Adds health bars to characters that spwan (watch later): https://www.youtube.com/watch?v=kQqqo_9FfsU
public class PlayerHealthBar : MonoBehaviour
{
    public Player _Player;
    public Image foregroundImage;
    float Health;
    float maxhealth;

    // Update is called once per frame
    void Update()
    {
        HealthFill();
    }

    public void HealthFill()
    {
        Health = _Player.getHealth();
        maxhealth = _Player.getMaxHealth();
        foregroundImage.fillAmount = Health / maxhealth;
        //Debug.Log(Health.ToString());
    }
}
