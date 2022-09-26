using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthScript
{

    private int currentHealth;
    private int currentMaxHealth;


    public int Health
    {
        get
        {
            return currentHealth;

        }
        set
        {

            currentHealth = value;

        }

    }

    public int MaxHealth
    {
        get
        {

            return currentMaxHealth;

        }
        set
        {

            currentMaxHealth = value;

        }
    }
    public HealthScript(int health, int maxHealth)
    {

        currentHealth = health;
        currentMaxHealth = maxHealth;

    }

    public void Damage(int damageAmount)
    {
        if(currentHealth > 0)
        {
        
        currentHealth -= damageAmount;
        

        }
    }


    public void Heal(int healAmount)
    {
        if (currentMaxHealth < healAmount)
        {
            currentHealth += healAmount;

        }
        if (currentHealth > currentMaxHealth)
        {

            currentHealth = currentMaxHealth;

        }
    }

}