using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialCanvasTextHandler : MonoBehaviour
{
    public List<Participant> ParticipantsCopy;
    [SerializeField]
    Text[] amountOfPeopleInTeamTexts;
    [SerializeField]
    int[] amountOfPeopleInTeamCount;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < amountOfPeopleInTeamCount.Length; i++)
        {
            amountOfPeopleInTeamCount[i] = 0;
        }

        foreach (Participant p in TeamManager.instance.Participants)
        {
            amountOfPeopleInTeamCount[p.team]++;
        }
        for (int i = 0; i < amountOfPeopleInTeamTexts.Length; i++)
        {
            amountOfPeopleInTeamTexts[i].text = "People in Team " + ((teamColors)i) + ":  " + amountOfPeopleInTeamCount[i].ToString();
        }
    }
}
