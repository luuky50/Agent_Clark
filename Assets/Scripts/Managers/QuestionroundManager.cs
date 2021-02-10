using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestionroundManager : SingletonComponent<QuestionroundManager>
{
    Dictionary<string, string> Questions = new Dictionary<string, string>()
    {
        {"What year is it?\n" +
            "Example: !answer 2014", "2021"}
    };

    GameObject QuestionRoundPanel;
    
    KeyValuePair<string, string> currentQuestion;
    void Start()
    {
        InitializeQuestionRoundUI();
    }

    private void InitializeQuestionRoundUI()
    {
        QuestionRoundPanel = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BeginQuestionRound();
        }
    }

    public void BeginQuestionRound()
    {
        currentQuestion = Questions.ElementAt(Random.Range(0, Questions.Count - 1));
        QuestionRoundPanel.GetComponentInChildren<Text>().text = currentQuestion.Key;
    }

    public void ValidateQuestion(string Answer)
    {
        if (currentQuestion.Value == Answer)
        {
            Debug.Log("Question Answerd Right!");
        }
        else
        {
            Debug.Log(currentQuestion.Value);
            Debug.Log("Question Answerd Wrong!");
        }
    }
}
