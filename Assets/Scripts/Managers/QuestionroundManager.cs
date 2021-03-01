﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum multipleChoiceAnswers
{
    a = 0,
    b = 1,
    c = 2,
    d = 3
}

public class QuestionroundManager : SingletonComponent<QuestionroundManager>
{
    [SerializeField]
    private Dictionary<string, string> OpenQuestions = new Dictionary<string, string>()
    {
        {"What year is it?\n" +
            "Example: !answer 2014", "2021"}
    };

    private List<MultipleChoiceQuestion> multipleChoiceQuestions = new List<MultipleChoiceQuestion>() {
        new MultipleChoiceQuestion("What year is it?","2021","2022","2023","2024"),

    };



    [SerializeField] Text[] teamOneStatusText;


    private Dictionary<int, Dictionary<int, bool>> PlayerAnswersOfMultipleChoice = new Dictionary<int, Dictionary<int, bool>>();

    private GameObject QuestionRoundPanel;

    private MultipleChoiceQuestion currentMultipleChoiceQuestion;

    private KeyValuePair<string, string> currentQuestion;
    private int correctAnswer;
    private bool isMultipleChoice;
    private void Start()
    {
        // TODO: initialize this only when we are in a scene where this is relevant
        isMultipleChoice = true;
        InitializeQuestionRoundUI();

    }

    private void InitializeQuestionRoundUI()
    {
        if (isMultipleChoice)
        {
            QuestionRoundPanel = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        }
        else
        {
            QuestionRoundPanel = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        }
    }

    private void InitializeAnswersOfTeamsList()
    {
        for (int i = 0; i < TeamManager.instance.amountOfTeams; i++)
        {
            PlayerAnswersOfMultipleChoice.Add(i, new Dictionary<int, bool>());
            Debug.Log(PlayerAnswersOfMultipleChoice.Count);
        }
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
        if (isMultipleChoice)
        {
            InitializeAnswersOfTeamsList();
            correctAnswer = Random.Range(0, 3);
            currentMultipleChoiceQuestion = multipleChoiceQuestions[Random.Range(0, multipleChoiceQuestions.Count - 1)];
            QuestionRoundPanel.transform.GetChild(0).GetComponent<Text>().text = currentMultipleChoiceQuestion.Question;
            var answers = QuestionRoundPanel.transform.GetChild(1).GetComponentsInChildren<Text>();

            int goodQuestionPosition = Random.Range(0, 4);
            answers[goodQuestionPosition].text = currentMultipleChoiceQuestion.Answer;
            for (int i = 0; i < answers.Length; i++)
            {
                if (goodQuestionPosition != i)
                {
                    answers[i].text = currentMultipleChoiceQuestion.WrongAnswerOne;
                }
            }

        }
        else
        {
            currentQuestion = OpenQuestions.ElementAt(Random.Range(0, OpenQuestions.Count - 1));
            QuestionRoundPanel.GetComponentInChildren<Text>().text = currentQuestion.Key;
        }
    }


    /// <summary>
    /// validates question, checks if it is good and adds it to the givin answers list
    /// </summary>
    /// <param name="message"></param>
    /// <param name="participantID"></param>
    public void ValidateClosedQuestion(string message, int participantID)
    {
        if (message == currentMultipleChoiceQuestion.Answer)
        {
            foreach (Participant p in TeamManager.instance.Participants)
            {
                if (p.ParticipantID == participantID)
                {
                    Debug.Log(p.team + "   and good");
                    if (!PlayerAnswersOfMultipleChoice[p.team].ContainsKey(participantID))
                    {
                        PlayerAnswersOfMultipleChoice[p.team].Add(participantID, true);
                    }
                    else
                    {
                        //TODO: message to sender containing that he already voted
                        Debug.Log("Already voted");
                    }
                    setUIPanel();
                }
            }
        }
        else
        {
            foreach (Participant p in TeamManager.instance.Participants)
            {
                if (p.ParticipantID == participantID)
                {
                    Debug.Log(p.team + "   and wrong");
                    if (!PlayerAnswersOfMultipleChoice[p.team].ContainsKey(participantID))
                    {
                        PlayerAnswersOfMultipleChoice[p.team].Add(participantID, false);
                    }
                    else
                    {
                        //TODO: message to sender containing that he already voted
                    }
                    setUIPanel();
                }
            }
        }
    }

    /// <summary>
    /// Validates if the given answer is correct
    /// </summary>
    /// <param name="Answer"></param>
    public void ValidateOpenQuestion(string Answer)
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

    private void setUIPanel()
    {
        int Good = 0;
        int Wrong = 0;
        for (int i = 0; i < PlayerAnswersOfMultipleChoice.Count; i++)
        {

            Dictionary<int, bool> answers = PlayerAnswersOfMultipleChoice[i];
            foreach (KeyValuePair<int, bool> answer in answers)
            {
                if (answer.Value)
                {
                    Good = +1;
                }
                else
                {
                    Wrong = +1;
                }
                int Status;
                if (Wrong > 0)
                {
                    Status = (Good / Wrong * 100);
                }
                else
                {
                    Status = 100;
                }
                teamOneStatusText[i].text = Status.ToString();
            }
        }
    }
}

public class MultipleChoiceQuestion
{
    public string Question;
    public string Answer;
    public string WrongAnswerOne;
    public string WrongAnswerTwo;
    public string WrongAnswerThree;
    public MultipleChoiceQuestion(string newQuestion, string newAnswer, string newWrongAnswerOne, string newWrongAnswerTwo, string newWrongAnswerThree)
    {
        Question = newQuestion;
        Answer = newAnswer;
        WrongAnswerOne = newWrongAnswerOne;
        WrongAnswerTwo = newWrongAnswerTwo;
        WrongAnswerThree = newWrongAnswerThree;
    }
}
