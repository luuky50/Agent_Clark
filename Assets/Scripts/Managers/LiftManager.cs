using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class LiftManager : SingletonComponent<LiftManager>
{

    private int secondsToWaitLift = 5;
    private bool isLiftClosed;

 
    //Tween liftTween;


    [SerializeField]
    List<GameObject> doors = new List<GameObject>();


    [SerializeField]
    private Transform endPointLift;

    private void Start()
    {
        DOTween.Init();
        //doors.Add()
    }
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




    public void OpenLift()
    {
        //liftTween.Rewind();
        foreach (var item in doors)
        {
            //sequenceLift.Append(item.transform.DOSmoothRewind());
            //TODO: Open the left with rewind
            Debug.Log("Rewinding");
        }
    }

    public void CloseLift(string _sceneName)
    {
        //Sequence sequenceLift = DOTween.Sequence();
        print(_sceneName);
        foreach (var item in doors)
        {
            item.transform.DOLocalMove(endPointLift.position, secondsToWaitLift);
        }

        LevelManager.instance.LoadLevel(_sceneName, 5);


    }

    /*IEnumerator LoadScene(string _sceneName, int _sceneNumber)
    {
        AsyncOperation asyncOperationLoad = null;

        yield return new WaitForSeconds(secondsToWaitLift);
        if (_sceneName == null)
        {
            asyncOperationLoad = SceneManager.LoadSceneAsync(_sceneNumber);
        }
        else
            asyncOperationLoad = SceneManager.LoadSceneAsync(_sceneName);

        Destroy(Player.instance.gameObject);

        while (!asyncOperationLoad.isDone)
        {
            yield return null;
        }

    }*/



}
