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
    Text theQuestion;
    [SerializeField]
    Text theTeam;


    [SerializeField]
    Text timeLeftText;

    [SerializeField]
    Text infoText;
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
        this.theQuestion.text = "The correct question was: " + theQuestion;
        this.theTeam.text = theTeam;
    }


    public void SetTimeLeftText(string timeLeft)
    {
        timeLeftText.text = timeLeft;
    }
    float timer;
    int currentInfoText;
    [SerializeField]
    int infoTextRotateTime;
    [SerializeField]
    string[] infoTextPosibilities;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > infoTextRotateTime)
        {
            timer = 0;
            if (currentInfoText == infoTextPosibilities.Length - 1)
            {
                currentInfoText = 0;
            } else
            {
                currentInfoText++;
            }
            SetInfoText(infoTextPosibilities[currentInfoText]);
        }
    }

    public void SetInfoText(string infoText)
    {
        this.infoText.text = infoText;
    }
}