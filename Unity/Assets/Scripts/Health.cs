using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Action Died;

    public void Damage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth > 0) return;
        currentHealth = 0;

        Died?.Invoke();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }
}
