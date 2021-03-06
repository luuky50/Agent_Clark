﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RobotHealth : MonoBehaviour
{
    [SerializeField]
    private float health;
    private float damage;

    [SerializeField]
    private int currentLives;

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
       
        LevelCanvasHandler.instance.SetTeamHealth(utils.getTeam(gameObject), health);
        Debug.Log(gameObject.transform.Find("teamIndicator").GetComponentInChildren<Slider>().value);
        gameObject.transform.Find("teamIndicator").GetComponentInChildren<Slider>().value = health;
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
        health = 100;
       

        currentLives--;
        LevelCanvasHandler.instance.SetTeamRespawns(utils.getTeam(gameObject), currentLives);
        if (currentLives == 0)
        {
            RobotManager.instance.lives--;
            gameObject.SetActive(false);
            if(RobotManager.instance.lives == 0)
            {
                EndManager.instance.EndGame(true);
            }
        }
        else
        {
            RobotManager.instance.RespawnRobot(gameObject);
        }
    }
}
