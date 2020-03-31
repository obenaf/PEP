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

    // Update is called once per frame
    void Update()
    {
        HealthFill();
    }

    public void HealthFill()
    {
        Health = _Enemy.getHealth();
        foregroundImage.fillAmount = Health / 10f;
        Debug.Log(Health.ToString());
    }
}
