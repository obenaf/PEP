using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Modified from how to make a health bar at: https://www.youtube.com/watch?v=CA2snUe7ARM
// Adds health bars to characters that spwan (watch later): https://www.youtube.com/watch?v=kQqqo_9FfsU
public class PlayerHealthBar : MonoBehaviour
{
    private HealthFill healthfill;

    private void Awake()
    {
        //healthfill = new HealthFill();
    }

    // Update is called once per frame
    void Update()
    {
        healthfill.changeHealthFill();
    }

}

public class HealthFill
    {
        public Player _Player;
        public Image foregroundImage;
        float Health;

        public void changeHealthFill()
        {
            Health = _Player.getHealth();
            foregroundImage.fillAmount = Health / 10f;
            Debug.Log(Health.ToString());
        }
        
    }