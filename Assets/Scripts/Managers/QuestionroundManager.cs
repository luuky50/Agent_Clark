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
<<<<<<< Updated upstream
=======
        isMultipleChoice = false;
>>>>>>> Stashed changes
        InitializeQuestionRoundUI();
    }

    private void InitializeQuestionRoundUI()
    {
<<<<<<< Updated upstream
        QuestionRoundPanel = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
=======
        if (isMultipleChoice)
        {
            QuestionRoundPanel = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
            QuestionRoundPanel.transform.GetChild(0).gameObject.SetActive(true);
            QuestionRoundPanel.transform.GetChild(1).gameObject.SetActive(true);
            QuestionRoundPanel.transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            QuestionRoundPanel = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
            QuestionRoundPanel.transform.GetChild(0).gameObject.SetActive(false);
            QuestionRoundPanel.transform.GetChild(1).gameObject.SetActive(false);
            QuestionRoundPanel.transform.GetChild(2).gameObject.SetActive(true);
        }
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        currentQuestion = Questions.ElementAt(Random.Range(0, Questions.Count - 1));
        QuestionRoundPanel.GetComponentInChildren<Text>().text = currentQuestion.Key;
=======
        if (isMultipleChoice)
        {
            InitializeAnswersOfTeamsList();
            correctAnswer = Random.Range(0, 3);
            currentMultipleChoiceQuestion = multipleChoiceQuestions[Random.Range(0, multipleChoiceQuestions.Count - 1)];
            QuestionRoundPanel.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentMultipleChoiceQuestion.Question;
            var answers = QuestionRoundPanel.transform.GetChild(0).GetComponentsInChildren<Text>();

            int goodQuestionPosition = Random.Range(0, 4);
            answers[goodQuestionPosition].text = currentMultipleChoiceQuestion.Answer;

            List<string> wrongAnswers = new List<string>() {
                {currentMultipleChoiceQuestion.WrongAnswerOne },
                {currentMultipleChoiceQuestion.WrongAnswerTwo },
                {currentMultipleChoiceQuestion.WrongAnswerThree }
            };
            for (int i = 0; i < answers.Length; i++)
            {
                if (goodQuestionPosition != i)
                {
                    answers[i].text = wrongAnswers[Random.Range(0,3)];
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
>>>>>>> Stashed changes
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
