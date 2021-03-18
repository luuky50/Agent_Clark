using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : SingletonComponent<DamageManager>
{
    List<RobotHealth> robotHealths = new List<RobotHealth>();
    [SerializeField]
    private PlayerHealth playerHealth;

    public void Init()
    {
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<PlayerHealth>();
    }

    void Start()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Robot"))
        {
            robotHealths.Add(item.GetComponent<RobotHealth>());
        }
    }

    /// <summary>
    /// Handles dealing damage to player
    /// </summary>
    /// <param name="damage"></param>
    public void DamageToPlayer(float damage)
    {
        playerHealth.IngoingDamage(damage);
    }
    /// <summary>
    /// handles damage dealt to given robot
    /// </summary>
    /// <param name="damage">amount of damage</param>
    /// <param name="robotHealth">the desired robot as 'RobotHealth' object </param>
    public void DamageToRobot(float damage, RobotHealth robotHealth)
    {
        robotHealth?.IngoingDamage(damage);
    }

    /// <summary>
    /// handles damage dealt to given robot
    /// </summary>
    /// <param name="damage">amount of damage</param>
    /// <param name="robotHealth">the desired robot as index, can be null </param>
    public void DamageToRobot(float damage, int robotHealth)
    {
        robotHealths[robotHealth].IngoingDamage(damage);
    }
}
