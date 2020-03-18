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
    public Image foregroundImage;
    
    private void Start()
    {
        foregroundImage.fillAmount = _Player.getHealth();
        //_Player.damagePlayer(1);
    }
}
