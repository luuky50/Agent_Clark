using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum{
    
}

public class RobotMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody robot;
    private Transform currentSide;
    void Start()
    {
        robot = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveForward();
        if (Input.GetKey(KeyCode.A))
        {
            LeftRightDownUp(true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            LeftRightDownUp(false);
        }
    }

    private void MoveForward()
    {
        robot.velocity = transform.forward * 0.0001f;
    }

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.transform.gameObject);
        if (col.gameObject.tag == "vertical" && col.gameObject.transform != currentSide)
        {
            robot.transform.Rotate(0f, 180f, 0f);
        }
        else if (col.gameObject.tag == "floor" && col.gameObject.transform != currentSide)
        {
            robot.transform.Rotate(0f, 0f, 0f);
        }
        else if (col.transform.transform.tag == "leftwall" && col.gameObject.transform != currentSide)
        {
            robot.transform.Rotate(0f, 0f, -90f);

        }
        else if (col.transform.transform.tag == "rightwall" && col.gameObject.transform != currentSide)
        {
            robot.transform.Rotate(0f, 0f, 90f);
        }
        currentSide = col.gameObject.transform;
    }

    private void LeftRightDownUp(bool isLeft)
    {
        if (!isLeft)
        {
            robot.velocity = transform.right * 8;
        }
        else
        {
            robot.velocity = transform.right * -8;
        }
    }
}
