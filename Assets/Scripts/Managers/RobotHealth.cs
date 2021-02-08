using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHealth : MonoBehaviour
{
    private float health;
    private float damage;
    public RobotHealth(float newHealth, float newDamage)
    {
        health = newHealth;
        damage = newDamage;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            OutgoingDamage(damage);
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// handles ingoing damage
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
        DamageManager.instance.DamageToPlayer(damage);
    }
}
