using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We hit: " + other.gameObject.name);
        if(other.gameObject.CompareTag("Player"))
        {
            Player();
        }
        else if(other.gameObject.CompareTag("Robot"))
        {
            GameObject enemyRobot = other.gameObject;

            Enemy(enemyRobot);
        }
        Destroy(gameObject);
    }

    private void Player()
    {
        Debug.Log("PLayer has been hit");
        DamageManager.instance.DamageToPlayer(5);
    }

    private void Enemy(GameObject enemyRobot)
    {
        Debug.Log("Enemy has been hit");
        print("currentRobot: " + enemyRobot.name);
        DamageManager.instance.DamageToRobot(10, enemyRobot.GetComponentInParent<RobotHealth>());
    }



}
