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

    public GameObject upButton;


    List<Tween> liftTween = new List<Tween>();


    [SerializeField]
    List<GameObject> doors = new List<GameObject>();


    [SerializeField]
    private Transform endPointLift;


    private void Start()
    {
        OpenLift();
    }

    private void OpenLift()
    {
        liftTween.Clear();
        foreach (var item in doors)
        {
            Vector3 loc = endPointLift.position;
            var tween = item.transform.DOLocalMove(loc, secondsToWaitLift);
            liftTween.Add(tween);

            Sequence s = DOTween.Sequence();
            s.Append(tween);
            s.AppendInterval(2.5f);
            s.SetLoops(2, LoopType.Yoyo);
            s.OnComplete(() => {  });
            s.Play();

            //sequenceLift.Append(item.transform.DOLocalMove(endPointLift.position, secondsToWaitLift));
        }
        Debug.Log("Is the lift closed? " + isLiftClosed);
        //OpenLift();
    }

    public void CloseLift(string _sceneName)
    {
        //Sequence sequenceLift = DOTween.Sequence();
        print(_sceneName);
        liftTween.Clear();
        foreach (var item in doors)
        {
            Vector3 loc = endPointLift.position;
            var tween = item.transform.DOLocalMove(loc, secondsToWaitLift);
            liftTween.Add(tween);
            Sequence s = DOTween.Sequence();
            s.Append(tween);
            s.OnComplete(() => { LevelManager.instance.LoadLevel(_sceneName, 0, true, false); });
            s.Play();

            //item.transform.DOLocalMove(endPointLift.position, secondsToWaitLift);
        }

        //LevelManager.instance.LoadLevel(_sceneName, 5, true);


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
