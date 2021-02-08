using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float damage;

    public PlayerHealth(float health, float damage)
    {
        this.health = health;
        this.damage = damage;
    }

    /// <summary>
    /// handles ingoig damage
    /// </summary>
    /// <param name="damage"></param>
    public void IngoingDamage(float damage)
    {
        health -= damage;
    }

    /// <summary>
    /// handles outgoing damage
    /// </summary>
    /// <param name="damage"></param>
    public void OutgoingDamage(float damage)
    {
        DamageManager.instance.DamageToRobot(damage, 0);
    }
}
