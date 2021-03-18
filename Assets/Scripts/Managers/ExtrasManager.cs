using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExtrasManager : SingletonComponent<ExtrasManager>
{
    public bool isPlaying = false;
    bool questionIsActive = false;
    int timeUntillStartQuestionRound = 30;
    float timer;
    public bool isMultipleChoice;
    public Text timeLeft;

    float timeLeftToAnswer = 20;

    public void extraManagerInit()
    {

        isPlaying = true;
        StartCoroutine(StartPlaying());
    }

    IEnumerator StartPlaying()
    {
        while (isPlaying)
        {
            timeLeftToAnswer -= Time.deltaTime;
            timer += Time.deltaTime;

            timeLeft.text = ((int)timeLeftToAnswer).ToString();

            if (timer > timeUntillStartQuestionRound)
            {
                timer = 0;
                timeLeftToAnswer = 20;
                _StartQuestionRound();
                questionIsActive = true;
            }
            if (questionIsActive)
            {
                if (timeLeftToAnswer < 0.1f)
                {
                    questionIsActive = false;
                    _EndQuestionRound();
                    yield return null;
                }
            }
        }
    }



    private void _StartQuestionRound()
    {
        isMultipleChoice = !isMultipleChoice;
        QuestionroundManager.instance.InitializeQuestionRoundUI(isMultipleChoice);
    }

    private void _EndQuestionRound()
    {
        QuestionroundManager.instance.EndQuestionRound();
    }

    public void GivePowerupToRobot()
    {
        Debug.Log(isMultipleChoice);
        if (isMultipleChoice)
        {
            SwarmManager.instance.ShootTheSwarm();
        }
        else
        {
            Laser.instance.Shoot();
        }
    }
}
