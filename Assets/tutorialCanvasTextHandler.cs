using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialCanvasTextHandler : MonoBehaviour
{
    public List<Participant> ParticipantsCopy = new List<Participant>();
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
        if (ParticipantsCopy != TeamManager.instance.Participants)
        {
            ParticipantsCopy = TeamManager.instance.Participants;
            foreach(Participant p in ParticipantsCopy)
            {
                amountOfPeopleInTeamCount[p.team]++; 
            }
            for (int i = 0; i < amountOfPeopleInTeamTexts.Length; i++)
            {
                amountOfPeopleInTeamTexts[i].text = amountOfPeopleInTeamCount[i].ToString();
            }
        }
    }

    
}
