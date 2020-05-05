using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Enemy _Enemy;
    public Image foregroundImage;
    float Health;
    float MaxHealth;

    // Update is called once per frame
    void Update()
    {
        HealthFill();
    }

    public void HealthFill()
    {
        MaxHealth = _Enemy.getMaxHealth();
        Health = _Enemy.getHealth();
        foregroundImage.fillAmount = Health / MaxHealth;
        //Debug.Log(Health.ToString());
    }
}
