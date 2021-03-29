using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class RobotManager : SingletonComponent<RobotManager>
{

    public Dictionary<int, GameObject> robots = new Dictionary<int, GameObject>();
    [SerializeField]
    List<GameObject> spawnPoints = new List<GameObject>();
    public GameObject[] robotsInScene;
    // Start is called before the first frame update
    public int lives = 4;

    void Start()
    {
        ConnectRobotToATeam();
      //  StartCoroutine(generateRobots());
    }

    public IEnumerator generateRobots(int delay)
    {
        foreach (KeyValuePair<int, GameObject> kvp in robots)
        {
            RespawnRobot(kvp.Value);
            yield return new WaitForSeconds(delay);
        }
    }

    public void MoveRobot(int participantID, SidewaysDirections dir)
    {
        robots[participantID].GetComponent<RobotMovement>().MoveSideways(dir);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RespawnRobot(robots[Random.Range(0, 3)]);
        }
    }

    public void RespawnRobot(GameObject gameObject)
    {
        gameObject.GetComponent<RobotMovement>().canMove = false;
        int respawnPoint = Random.Range(0, 6);
        gameObject.transform.position = spawnPoints[respawnPoint].transform.position;
        if (!gameObject.GetComponent<RobotMovement>().isEnd)
        {
            gameObject.transform.DOMove(spawnPoints[respawnPoint].transform.GetChild(Random.Range(0, 2)).transform.position, 1).OnComplete(() =>
            {
                gameObject.GetComponent<RobotMovement>().canMove = true;
            });
        }
    }

    void ConnectRobotToATeam()
    {
        List<int> indexesAlreadyGiven = new List<int>();
        bool complete = false;
        while (!complete)
        {
            int randomIndex = Random.Range(0, TeamManager.instance.amountOfTeams);
            if (!indexesAlreadyGiven.Contains(randomIndex))
            {
                indexesAlreadyGiven.Add(randomIndex);
            }


            if (indexesAlreadyGiven.Count == TeamManager.instance.amountOfTeams) { complete = true; }
        }



        for (int i = 0; i < TeamManager.instance.amountOfTeams; i++)
        {
            robots[i] = robotsInScene[indexesAlreadyGiven[i]];
            robots[i].transform.GetChild(2).GetComponent<Canvas>().worldCamera = Camera.main;
            robots[i].transform.GetChild(2).GetComponentInChildren<Text>().text = "The robot of team: " + (i + 1);
        }

    }
}
