using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestionroundManager : SingletonComponent<QuestionroundManager>
{
    [SerializeField]
    private Dictionary<string, string> Questions = new Dictionary<string, string>()
    {
        {"What year is it?\n" +
            "Example: !answer 2014", "2021"}
    };

    private GameObject QuestionRoundPanel;
    
    private KeyValuePair<string, string> currentQuestion;
    private void Start()
    {
        // TODO: initialize this only when we are in a scene where this is relevant
        InitializeQuestionRoundUI();
    }

    private void InitializeQuestionRoundUI()
    {
        QuestionRoundPanel = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        // TODO: Implement logic for when rounds should begin
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BeginQuestionRound();
        }
    }

    /// <summary>
    /// Handles initiation of a questionround. 
    /// </summary>
    public void BeginQuestionRound()
    {
        currentQuestion = Questions.ElementAt(Random.Range(0, Questions.Count - 1));
        QuestionRoundPanel.GetComponentInChildren<Text>().text = currentQuestion.Key;
    }

    /// <summary>
    /// Validates if the given answer is correct
    /// </summary>
    /// <param name="Answer"></param>
    public void ValidateQuestion(string Answer)
    {
        if (currentQuestion.Value == Answer)
        {
            Debug.Log("Question Answerd Right!");
        }
        else
        {
            Debug.Log("Question Answerd Wrong!");
        }
    }
}
