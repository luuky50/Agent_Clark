using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : SingletonComponent<TeamManager>
{
    private Dictionary<int, List<Participant>> teams = new Dictionary<int, List<Participant>>();
    void Start()
    {
        // TODO: for showcase purposes only
        InitializeTeamInstances(4);
    }

    void Update()
    {
        // TODO: for showcase purposes only
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DebugAll();
        }
    }

    // TODO: This should happen when beginning a game. Called in LevelManager?
    void InitializeTeamInstances(int amountOfTeams)
    {
        for (int i = 0; i < amountOfTeams; i++)
        {
            List<Participant> _participantsOfTeam = new List<Participant>();
            teams.Add(i, _participantsOfTeam);
        }
    }

    /// <summary>
    /// Adds a given participant to the given 'teamIndex'
    /// </summary>
    /// <param name="participant"></param>
    /// <param name="teamIndex"></param>
    public void addParticipant(Participant participant, int teamIndex)
    {
        try
        {
            List<Participant> _participantsOfTeam = new List<Participant>(teams[teamIndex]);
           _participantsOfTeam.Add(participant);
            teams[teamIndex] = _participantsOfTeam;
        }
        catch (Exception e)
        {
            Debug.LogError("Could not add participant!  " + e);
        }
    }

    // TODO: for showcase purposes only
    void DebugAll()
    {
        foreach (KeyValuePair<int, List<Participant>> kvp in teams)
        {
            foreach(Participant item in kvp.Value)
            {
                Debug.Log(item.ParticipantID);
            }
        }
    }
}

/// <summary>
/// Object that holds all information about participant
/// </summary>
public class Participant
{
    public string ParticipantID;
    public Participant(string newParticipantID)
    {
        ParticipantID = newParticipantID;
    }
}
