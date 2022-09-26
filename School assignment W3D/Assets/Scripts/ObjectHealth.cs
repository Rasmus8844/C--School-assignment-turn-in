using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    [SerializeField] int currentHealth;
    public HealthScript objectHealth;

    public void Start()
    {
        objectHealth = new HealthScript(currentHealth, currentHealth);
    }

    public void TakeDamage(int damage)
    {

        objectHealth.Damage(damage);

    }

    public int GetHealth()
    {

        return objectHealth.Health;

    }

}
