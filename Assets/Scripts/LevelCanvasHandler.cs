using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelCanvasHandler : SingletonComponent<LevelCanvasHandler>
{
    [SerializeField]
    Text[] teamHealthText;
    [SerializeField]
    Text[] teamRespawnsText;

    [SerializeField]
    Text VRHealthText;


    [SerializeField]
    Text TheQuestion;
    [SerializeField]
    Text TheTeam;
    public void SetVRPlayerHealth(float health)
    {
        VRHealthText.text = "Health: " + health;
    }

    public void SetTeamHealth(int team, float health)
    {
        teamHealthText[team].text = "Health: " + health.ToString();
    }

    public void SetTeamRespawns(int team, int respawns)
    {
        teamRespawnsText[team].text = "Respawns" + respawns.ToString();
    }

    public void SetRightQuestionText(string theQuestion, string theTeam)
    {
        TheQuestion.text = "The correct question was: " + theQuestion;
        TheTeam.text = theTeam;
    }
}