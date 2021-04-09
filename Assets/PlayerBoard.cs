using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBoard : MonoBehaviour
{
    [SerializeField]
    TextMeshPro redList;

    [SerializeField]
    TextMeshPro greenList;

    [SerializeField]
    TextMeshPro blueList;

    [SerializeField]
    TextMeshPro yellowList;


    void Start()
    {
        TeamManager.instance.completed += Instance_completed;
        Instance_completed();
        //TeamManager.instance.Participants
    }

    private void Instance_completed()
    {
        redList.text = "";
        greenList.text = "";
        blueList.text = "";
        yellowList.text = "";
        foreach (var item in TeamManager.instance.Participants)
        {
            switch (item.team)
            {
                case 0:
                    redList.text += item.userName + "\n";
                    break;
                case 1:
                    yellowList.text += item.userName + "\n";
                    break;
                case 2:
                    blueList.text += item.userName + "\n";
                    break;
                case 3:
                    greenList.text += item.userName + "\n";
                    break;
            }
        }
    }
}
