using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class ButtonManager : MonoBehaviour
{

    [SerializeField]
    private Text twitchName;

    public void StartButton()
    {
        TwitchClient.instance.StartTwitch(twitchName);
    }

    public void SwitchToScene()
    {
        Destroy(Player.instance.gameObject);
        LevelManager.instance.LoadLevel("Tutorial", 0, true);
    }

    public void SwitchToSceneTemp()
    {
        Destroy(Player.instance.gameObject);
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        LevelManager.instance.QuitApplication();
    }


}
