using UnityEngine.AI;
using UnityEngine;

public class NormalRobotBrain : MonoBehaviour, IRobotAI
{
    Vector3 Destination;
    NavMeshAgent agent;
    public void MoveTowardsDestination()
    {
        agent.SetDestination(Destination);
    }

    void Start()
    {
        Destination = GameObject.FindGameObjectWithTag("PlayerPos").transform.position;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

}
