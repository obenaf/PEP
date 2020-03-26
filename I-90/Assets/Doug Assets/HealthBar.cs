using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Learned how to make a health bar from: https://www.youtube.com/watch?v=CA2snUe7ARM
// Adds health bars to characters that spwan (watch later): https://www.youtube.com/watch?v=kQqqo_9FfsU
public class HealthBar : MonoBehaviour
{
    public Player _Player;
    public Enemy _Enemy;
    int enemy_H, player_H, Total_H = 10;
    public Image foregroundImage;
    
    //Fills healthbar at start
    private void Start()
    {
        foregroundImage.fillAmount = _Player.getHealth();
        foregroundImage.fillAmount = _Enemy.getHealth();
    }

    // update to change healthbar
    private void FixedUpdate()
    {
        foregroundImage.fillAmount = enemy_H;
        //foregroundImage.fillAmount = _Enemy.getHealth();
    }

    private void PercentHealth()
    {
        enemy_H = _Enemy.getHealth() / Total_H;
        player_H = _Player.getHealth() / Total_H;
    } 
}
