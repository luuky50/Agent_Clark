using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchToScene : MonoBehaviour
{
    public void GoToScene() {

        SceneManager.LoadScene(0);
    }
}
