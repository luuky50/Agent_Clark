using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We hit something!");
        if(other.gameObject.tag == "Player")
        {
            Player();
        }
        else if(other.gameObject.tag == "Enemy")
        {
            Enemy();
        }
        Destroy(gameObject);
    }

    private void Player()
    {
        //TODO: Make the players health go down

    }

    private void Enemy()
    {
        //TODO: Make the enemy's health go down
    }



}
