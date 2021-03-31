using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health;
    private float damage;
    /// Contains information about this object's current health and the damage this object deals
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
        Debug.Log("Got some damage: " + damage);
        if (health <= 0)
            EndManager.instance.EndGame(false);
        else
            health -= damage;
        LevelCanvasHandler.instance.SetVRPlayerHealth(health);
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
