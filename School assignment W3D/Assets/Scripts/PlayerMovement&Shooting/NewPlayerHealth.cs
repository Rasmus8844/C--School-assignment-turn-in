using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerHealth : MonoBehaviour
{
    [SerializeField] int currentHealth;
    public HealthScript playerHealth;
    public GameObject player;
    public HealthBar healthBar;

    public void Start()
    {
        playerHealth = new HealthScript(currentHealth, currentHealth);
        healthBar.SetMaxHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {

        playerHealth.Damage(damage);

        healthBar.SetHealth(currentHealth -= damage);

    }

    public void HealDamage(int heal)
    {

        playerHealth.Heal(heal);

        healthBar.SetHealth(currentHealth += heal);


    }

    public int GetHealth()
    {

        return playerHealth.Health;

    }
}
