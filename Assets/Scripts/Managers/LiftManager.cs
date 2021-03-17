using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class LiftManager : MonoBehaviour
{

    private int secondsToWaitLift = 5;
    private bool isLiftClosed;

    Sequence sequenceLift = DOTween.Sequence();
    Tween liftTween;


    [SerializeField]
    List<GameObject> doors = new List<GameObject>();


    [SerializeField]
    private Transform endPointLift;



    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            OpenLift();
        }
    }

    private void Start()
    {
        foreach (var item in doors)
        {
            liftTween = item.transform.DOLocalMove(endPointLift.position, secondsToWaitLift);
            liftTween.Play();
            StartCoroutine(RewindTime());
            //sequenceLift.Append(item.transform.DOLocalMove(endPointLift.position, secondsToWaitLift));
        }
        Debug.Log("Is the lift closed? " + isLiftClosed);
        
        //OpenLift();
    }

    IEnumerator RewindTime()
    {
        yield return new WaitForSeconds(5);
        liftTween.Rewind();

    }*/

    public void LoadSceneInt(int sceneNumber)
    {
        CloseLift(null, sceneNumber);
    }

    public void LoadSceneString(string sceneName)
    {
        Debug.Log("Button Pressed with string");
        CloseLift(sceneName, 0);

    }

    public void OpenLift()
    {
        liftTween.Rewind();
        foreach (var item in doors)
        {
            //sequenceLift.Append(item.transform.DOSmoothRewind());
            //TODO: Open the left with rewind
            Debug.Log("Rewinding");
        }
    }

    private void CloseLift(string _sceneName, int _sceneNumber)
    {
        print(_sceneName);
        print(_sceneNumber);
        sequenceLift.SetAutoKill(false);
        foreach (var item in doors)
        {
            sequenceLift.Append(item.transform.DOLocalMove(endPointLift.position, secondsToWaitLift)).OnComplete(() =>
            {
                isLiftClosed = true;
            });
        }

        StartCoroutine(LoadScene(_sceneName, _sceneNumber));



    }
    IEnumerator LoadScene(string _sceneName, int _sceneNumber)
    {
        AsyncOperation asyncOperationLoad = null;

        yield return new WaitForSeconds(secondsToWaitLift);
        if (_sceneName == null)
            asyncOperationLoad = SceneManager.LoadSceneAsync(_sceneNumber);
        else
            asyncOperationLoad = SceneManager.LoadSceneAsync(_sceneName);


        while (!asyncOperationLoad.isDone)
        {
            yield return null;
        }

    }



}
