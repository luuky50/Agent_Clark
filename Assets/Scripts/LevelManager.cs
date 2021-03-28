using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;
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
        if(currentScene.name == "AI")
        {
            DamageManager.instance.Init();
            TwitchClient.instance.robotManager = GameObject.Find("Building").GetComponent<RobotManager>();
        }
        ExtrasManager.instance.isPlaying = false;


   

    }
    public void LoadLevel(string levelName, int waitTime, bool loadAsync)
    {
        //using async load in inspector
        GetComponent<SteamVR_LoadLevel>().levelName = levelName;
        GetComponent<SteamVR_LoadLevel>().loadAsync = loadAsync;
        GetComponent<SteamVR_LoadLevel>().postLoadTime = waitTime;
        GetComponent<SteamVR_LoadLevel>().Trigger();
    }

    public void LoadLevelWithoutVRIntergration(int level) {
        SceneManager.LoadScene(0);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}