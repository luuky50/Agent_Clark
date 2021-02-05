using UnityEngine;

enum SidewaysDirections
{
    up,
    down,
    left,
    right
}

public class RobotMovement : MonoBehaviour
{
    private GameObject RobotModel;
    private Rigidbody RobotObject;
    private bool onWall;
    //NOTE: for testing only
    [SerializeField]
    private int sidewaysSpeedMultiplier;
    //NOTE: for testing only
    [SerializeField]
    private float forwardSpeedMultiplier;
    private void Start()
    {
        RobotModel = gameObject.transform.GetChild(0).gameObject;
        RobotObject = gameObject.transform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveForward();

        // NOTE: for testing purposes only
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveSideways(SidewaysDirections.left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveSideways(SidewaysDirections.right);
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveSideways(SidewaysDirections.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveSideways(SidewaysDirections.down);
        }
    }

    private void MoveForward()
    {
        RobotObject.transform.position = new Vector3(RobotObject.transform.position.x, RobotObject.transform.position.y, RobotObject.transform.position.z + forwardSpeedMultiplier);
    }

    private void OnCollisionEnter(Collision col)
    {
        onWall = col.gameObject.tag == "vertical" ? true : false;
        RobotModel.transform.eulerAngles = col.gameObject.tag == "vertical"
            ? new Vector3(0f, 0f, 90f) : new Vector3(0f, 0f, 0f);
    }

    private void MoveSideways(SidewaysDirections direction)
    {
        if (direction == SidewaysDirections.up || direction == SidewaysDirections.down)
        {
            if (onWall)
                RobotObject.velocity = (direction == SidewaysDirections.up
                    ? Vector3.up : Vector3.down) * sidewaysSpeedMultiplier;
        }
        else if (direction == SidewaysDirections.left || direction == SidewaysDirections.right)
        {
            if (!onWall)
                RobotObject.velocity = (direction == SidewaysDirections.right
                    ? Vector3.left : Vector3.right) * sidewaysSpeedMultiplier;
        }
    }
}
