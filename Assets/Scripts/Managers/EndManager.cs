using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Valve.VR.InteractionSystem;

public class EndManager : SingletonComponent<EndManager>
{
    [SerializeField]
    private GameObject glass;

    [SerializeField]
    private GameObject walkArea;

    [SerializeField]
    private Vector3 endPoint;

    public void EndGame(bool isWin)
    {
        foreach (var item in RobotManager.instance.robots)
        {
            item.Value.GetComponent<RobotMovement>().isEnd = true;
        }
        StartCoroutine(RobotManager.instance.generateRobots(0));
        ExtrasManager.instance.isPlaying = false;
        if (isWin)
        {
            glass.transform.DOLocalMove(endPoint, 5);
            walkArea.GetComponent<TeleportArea>().SetLocked(false);
        }
        else
        {
            Destroy(Player.instance.gameObject);
            LevelManager.instance.LoadLevel("Tutorial", 0, true);
        }
    }


}
