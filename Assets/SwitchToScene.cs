using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;
public class SwitchToScene : MonoBehaviour
{

    public void GoToScene(int scene) {

        SceneManager.LoadScene(scene);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void DeleteCurrentPlayer()
    {
        Destroy(Player.instance.gameObject);
    }
}
