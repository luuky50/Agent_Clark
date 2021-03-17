﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : SingletonComponent<TeamManager>
{
    // keeps track of all the participants
    public List<Participant> Participants = new List<Participant>();
    // setting of how much teams there should be
    public int amountOfTeams = 1;

    void Update()
    {
        // TODO: for showcase purposes only
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DebugAll();
        }
    }

    /// <summary>
    /// Adds a given participant to the given 'teamIndex'
    /// </summary>
    /// <param name="participant"></param>
    public void addParticipant(Participant participant)
    {
        try
        {
            if (participant.team <= amountOfTeams)
            {
                Participants.Add(new Participant(participant.ParticipantID, participant.team));
            } else
            {
                throw new Exception("given team index exceeds given max amount of teams!");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Could not add participant!  " + e);
        }
    }

    // TODO: for showcase purposes only
    void DebugAll()
    {
        foreach (var item in Participants)
        {
            Debug.Log(item.team + "  " + item.ParticipantID); 
        }
    }
}

/// <summary>
/// Object that holds all information about participant
/// </summary>
public class Participant
{
    public int ParticipantID;
    public int team;
    public Participant(int newParticipantID, int newTeam)
    {
        ParticipantID = newParticipantID;
        team = newTeam;
    }
}
