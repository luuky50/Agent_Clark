using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class LevelManager : SingletonComponent<LevelManager>
{
    //TODO: Make list of scenes

    public Scene currentScene;
    void OnEnable()
    {

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    // called second
    void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene;
        if (currentScene.name == "AI")
        {
            MusicManager.instance.PlayAudio(MusicManager.instance.audioClips[2]);
            DamageManager.instance.Init();
            MiniGameManager.instance.Init();
        }
        if (currentScene.name == "Tutorial" || currentScene.name == "AI")
        {
            TwitchClient.instance.robotManager = GameObject.Find("Building").GetComponent<RobotManager>();
        }
        ExtrasManager.instance.isPlaying = false;
        if(currentScene.name == "EndScene")
        {
            MusicManager.instance.PlayAudio(MusicManager.instance.audioClips[3]);
        }
    }
    public void LoadLevel(string levelName, int waitTime, bool loadAsync, bool loadAdditive)
    {
        //using async load in inspector
        GetComponent<SteamVR_LoadLevel>().levelName = levelName;
        GetComponent<SteamVR_LoadLevel>().loadAsync = loadAsync;
        GetComponent<SteamVR_LoadLevel>().loadAdditive = loadAdditive;
        GetComponent<SteamVR_LoadLevel>().postLoadTime = waitTime;
        GetComponent<SteamVR_LoadLevel>().Trigger();
    }
    public void LoadLevelWithoutVRIntergration(int level)
    {
        SceneManager.LoadScene(0);
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}