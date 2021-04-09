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

    public void SwitchToScene(string _scene)
    {
        LevelManager.instance.LoadLevel(_scene, 0, true, false);
    }

    public void ExitButton()
    {
        LevelManager.instance.QuitApplication();
    }


}
