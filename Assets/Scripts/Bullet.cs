using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject enemyRobot;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We hit something!");
        if(other.gameObject.tag == "Player")
        {
            Player();
        }
        else if(other.gameObject.tag == "Enemy")
        {
            enemyRobot = other.gameObject;
            Enemy();
        }
        Destroy(gameObject);
    }

    private void Player()
    {
        Debug.Log("PLayer has been hit");
        DamageManager.instance.DamageToPlayer(5);
    }

    private void Enemy()
    {
        Debug.Log("Enemy has been hit");
        DamageManager.instance.DamageToRobot(5, enemyRobot.GetComponent<RobotHealth>());
    }



}
