using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackBulletController : MonoBehaviour
{
    [SerializeField] RobotMovement robotMovement;
    bool hackBulletActive = false;
    void Start()
    {

    }

    float timer;
    float interval;
    void Update()
    {
        timer += Time.deltaTime * 10;
        if (hackBulletActive)
        {
            hackBullet();
        }
    }

    void hackBullet()
    {
        if (timer > interval)
        {
            int leftRight = Random.Range(0, 2);

            if (leftRight == 0)
            {
                robotMovement.MoveSideways(SidewaysDirections.left);
                robotMovement.MoveSideways(SidewaysDirections.up);
            }
            else if (leftRight == 1)
            {
                robotMovement.MoveSideways(SidewaysDirections.down);
                robotMovement.MoveSideways(SidewaysDirections.right);
                //   Debug.Log("1");
            }

            timer = 0;
            interval = Random.Range(0, 20);
        }
    }
}
