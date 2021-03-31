using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class  utils : SingletonComponent<utils>
{
    public int getTeam(GameObject gameObject)
    {
        var robotTeam = from entry in RobotManager.instance.robots where entry.Value == gameObject select entry.Key;
        int _robotTeam = 0;
        foreach (var item in robotTeam)
        {
            _robotTeam = item;
        }
        return _robotTeam;
    }

    public int getTeam(int particitpantID)
    {
        int index = 0;
        foreach(Participant p in TeamManager.instance.Participants)
        {
            if (p.team == particitpantID)
            {
                return index;
            }
            index++;
        }
        return 0;
    }
}
