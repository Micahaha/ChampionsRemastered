using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{

    public event EventHandler OnHealthChanged;
     
    float health;
    float healthMax; // Represents total amount the Enemy or entity starts with
    public HealthSystem(float health)
    {
        this.health = health;
        health = healthMax;
    }

    public float GetHealth() 
    {
        return health;
    }

    public float GetHealthPercent() 
    {
        return health / healthMax;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    } 

    public void onDeath(GameObject old_obj) 
    {
        if (health == 0)
        {
            UnityEngine.Object.Destroy(old_obj);
        }
    }
}
