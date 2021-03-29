using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExtrasManager : SingletonComponent<ExtrasManager>
{
    public bool isPlaying = false;
    bool questionIsActive = false;
    [SerializeField]
    int timeUntillStartQuestionRound = 15;
    float timer;
    public bool isMultipleChoice;
    public Text timeLeft;

    [SerializeField]
    float timeLeftToAnswer = 20;
    public void extraManagerInit()
    {
        isPlaying = true;
    }

    void Update()
    {
        if (isPlaying)
        {
            timeLeftToAnswer -= Time.deltaTime;
            timer += Time.deltaTime;

            timeLeft.text = ((int)timeLeftToAnswer).ToString();

            if (timer > timeUntillStartQuestionRound)
            {
                timer = 0;
                timeLeftToAnswer = 15;
                _StartQuestionRound();
                questionIsActive = true;
            }
            if (questionIsActive)
            {
                if (timeLeftToAnswer < 0.1f)
                {
                    questionIsActive = false;

                    _EndQuestionRound();
          
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
        Debug.Log("LASER GIVEN");
        if (isMultipleChoice)
           QuestionroundManager.instance.EndMPQuestionRound();
    }

    public void ShootTheSwarm() {
        SwarmManager.instance.ShootTheSwarm();
    }

    public void GiveLaserToRobot(GameObject robot)
    {
            robot.transform.GetChild(1).GetComponent<Laser>().Shoot();
       
    }
}
