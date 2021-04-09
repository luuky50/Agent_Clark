using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject emitObject;
    public LineRenderer lr;

    float timer = 0;
    int timeToAim = 15;

    private void Start()
    {
        // lr = this.GetComponent<LineRenderer>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
    


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            laserDirection(SidewaysDirections.left);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) 
        { laserDirection(SidewaysDirections.down); }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        { laserDirection(SidewaysDirections.up); }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        { laserDirection(SidewaysDirections.right); }



        if (timer > timeToAim)
        {
            EndShoot();
        }
    }
   public void Shoot()
    {
        lr.SetPosition(1, new Vector3(0, 0, 50));
        timer = 0;
        this.transform.parent.GetComponent<RobotMovement>().canMove = false;
    }


    public void laserDirection(SidewaysDirections dir)
    {
        if (dir == SidewaysDirections.down)
        {
            emitObject.transform.eulerAngles = new Vector3(emitObject.transform.eulerAngles.x + 3, emitObject.transform.eulerAngles.y, emitObject.transform.eulerAngles.z);
        }
        else if (dir == SidewaysDirections.left)
        {
            emitObject.transform.eulerAngles = new Vector3(emitObject.transform.eulerAngles.x, emitObject.transform.eulerAngles.y - 3, emitObject.transform.eulerAngles.z);
        }


        else if (dir == SidewaysDirections.up)
        {
            emitObject.transform.eulerAngles = new Vector3(emitObject.transform.eulerAngles.x - 3, emitObject.transform.eulerAngles.y, emitObject.transform.eulerAngles.z);
        }
        else if (dir == SidewaysDirections.right)
        {
            emitObject.transform.eulerAngles = new Vector3(emitObject.transform.eulerAngles.x, emitObject.transform.eulerAngles.y + 3, emitObject.transform.eulerAngles.z);
        }
    }

    void EndShoot()
    {
        RaycastHit hit;
        this.transform.parent.GetComponent<RobotMovement>().canMove = true;
        if (Physics.Raycast(emitObject.transform.position, emitObject.transform.forward, out hit))
        {
            ///TODO: damage to health of Streamer
        }
        lr.SetPosition(1, new Vector3(0, 0, 0));
    }
}
