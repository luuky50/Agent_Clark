using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : SingletonComponent<MiniGameManager>
{
    public GameObject miniGamesParent;

    public List<GameObject> miniGames = new List<GameObject>();

    private GameObject miniGamePreFab;

    [SerializeField]
    private GameObject newGame;

    public void Init()
    {
        miniGamesParent = GameObject.Find("MiniGames");
    }
    public void StartMiniGame()
    {

        miniGamePreFab = miniGames[Random.Range(0, miniGames.Count)];
        
        newGame = Instantiate(miniGamePreFab, miniGamesParent.transform);

    }

    public void EndMiniGame()
    {
        Debug.Log("End minigame");
        Destroy(newGame);
    }

}
