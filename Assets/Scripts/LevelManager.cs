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
        if(currentScene.name == "AI")
        {
            DamageManager.instance.Init();
        }
        ExtrasManager.instance.isPlaying = false;


   

    }
    public void LoadLevel(string levelName, int waitTime)
    {
        //using async load in inspector
        GetComponent<SteamVR_LoadLevel>().levelName = levelName;
        GetComponent<SteamVR_LoadLevel>().postLoadTime = waitTime;
        GetComponent<SteamVR_LoadLevel>().Trigger();
    }

}