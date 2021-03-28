using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenHandler : MonoBehaviour
{
    [SerializeField]
    Text winningTeamText;
    private void Start()
    {
     //   SetUIWinningTeamText(/*manager,instance.team*/);
    }
    void SetUIWinningTeamText(int winningTeam)
    {
        if (winningTeam == 0) {
            winningTeamText.text = "The streamer has won!";
        }
        else if (winningTeam == 1)
        {
            winningTeamText.text = "The chat has won!";
        }
    }
}
