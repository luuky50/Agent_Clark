using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAI : MonoBehaviour
{
    [SerializeField]
    Rigidbody robot;
    void Start()
    {
        robot = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        robot.velocity = transform.forward * 1f;
    }
}
