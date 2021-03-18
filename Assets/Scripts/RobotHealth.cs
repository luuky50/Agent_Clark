using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotHealth : MonoBehaviour
{
    [SerializeField]
    private float health;
    private float damage;

    private int deathCount;
    
    // information about current health and damage it can deal to others
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
       
        }
    }

    /// <summary>
    /// handles ingoing damage
    /// </summary>
    /// <param name="damage"></param>
    public void IngoingDamage(float damage)
    {
        Debug.Log("Got some damage: " + damage);
        if (health > 0)
            health -= damage;
        else
            Death();

    }

    /// <summary>
    /// handles outgoing damage
    /// </summary>
    /// <param name="damage"></param>
    public void OutgoingDamage(float damage)
    {
        DamageManager.instance.DamageToPlayer(damage);
    }

    private void Death()
    {
        this.transform.position = new Vector3(-11.5f, 2.8f, -19.08f);
        health = 100;
        deathCount++;
        if (deathCount == 4)
        {
            SceneManager.LoadScene(3);
        }
    }
}
