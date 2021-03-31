using System.Collections.Generic;
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
        {"How many time zones are there in Russia?", "11"},
         {"What’s the national flower of Japan?", "Cherry blossom"},
  {"How many stripes are there on the US flag?", "13"},
  {"What’s the national animal of Australia?", "Kangaroo"},
  {"How many days does it take for the Earth to orbit the Sun?", "365"},
  {"Which of the following empires had no written language: Incan, Aztec, Egyptian, Roman?", "Incan"},
  {"Until 1923, what was the Turkish city of Istanbul called?", "Constantinople"},
  {"What country has the most islands in the world?", "Sweden"},
  {"What is the slang name for New York City, used by locals?", "Gotham"},
  {"Which famous graffiti artist comes from Bristol?", "Banksy"},

    };

    private List<MultipleChoiceQuestion> multipleChoiceQuestions = new List<MultipleChoiceQuestion>() {
        new MultipleChoiceQuestion("What is the longest that an elephant has ever lived?","86","17","49","142"),
           new MultipleChoiceQuestion("How many rings are on the Olympic flag?","5","None","4","7"),
           new MultipleChoiceQuestion(" How did Spider-Man get his powers?","Spider bit","Via Military","Woke up with","Born with"),
           new MultipleChoiceQuestion(" In darts, what's the most points you can score with a single throw?","60","20","50","100"),
           new MultipleChoiceQuestion(" Which of these animals does NOT appear in the Chinese zodiac?","Bear","Rabbit","Dragon","Dog"),
           new MultipleChoiceQuestion(" How many holes are on a standard bowling ball?","3","2","5","10"),

            new MultipleChoiceQuestion("What are the main colors on the flag of Spain?","Red and Yellow","Black-Yellow","Green-White","Blue-White"),
           new MultipleChoiceQuestion(" Which of these countries was NOT a part of the Soviet Union?","Poland","Belarus","Georgia","Ukraine"),
    };
    int bestTeam = 0;

    [SerializeField] Text[] teamScoreText;


    private Dictionary<int, Dictionary<int, bool>> PlayerAnswersOfMultipleChoice = new Dictionary<int, Dictionary<int, bool>>();

    private GameObject QuestionRoundPanel;

    private MultipleChoiceQuestion currentMultipleChoiceQuestion;

    private KeyValuePair<string, string> currentQuestion;
    private int correctAnswer;

    public void InitializeQuestionRoundUI(bool isMultipleChoice)
    {
        if (isMultipleChoice)
        {
            QuestionRoundPanel = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
            QuestionRoundPanel.SetActive(true);
            QuestionRoundPanel.transform.GetChild(0).gameObject.SetActive(true);
            QuestionRoundPanel.transform.GetChild(1).gameObject.SetActive(false);
            QuestionRoundPanel.transform.GetChild(2).gameObject.SetActive(true);
            BeginQuestionRound(isMultipleChoice);
        }
        else
        {
            QuestionRoundPanel.SetActive(true);
            QuestionRoundPanel = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
            QuestionRoundPanel.transform.GetChild(0).gameObject.SetActive(false);
            QuestionRoundPanel.transform.GetChild(1).gameObject.SetActive(true);
            QuestionRoundPanel.transform.GetChild(2).gameObject.SetActive(false);
            BeginQuestionRound(isMultipleChoice);

        }
    }

    private void InitializeAnswersOfTeamsList()
    {
        PlayerAnswersOfMultipleChoice = new Dictionary<int, Dictionary<int, bool>>();
        for (int i = 0; i < TeamManager.instance.amountOfTeams; i++)
        {
            PlayerAnswersOfMultipleChoice.Add(i, new Dictionary<int, bool>());
        }
    }


    /// <summary>
    /// Handles initiation of a questionround. 
    /// </summary>
    public void BeginQuestionRound(bool isMultipleChoice)
    {
        if (isMultipleChoice)
        {
            InitializeAnswersOfTeamsList();
            correctAnswer = Random.Range(0, 3);
            currentMultipleChoiceQuestion = multipleChoiceQuestions[Random.Range(0, multipleChoiceQuestions.Count - 1)];
            QuestionRoundPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentMultipleChoiceQuestion.Question;
            var answers = QuestionRoundPanel.transform.GetChild(2).GetComponentsInChildren<Text>();

            int goodQuestionPosition = Random.Range(0, 3);
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
                    answers[i].text = wrongAnswers[Random.Range(0, 3)];
                }
            }

        }
        else
        {
            currentQuestion = OpenQuestions.ElementAt(Random.Range(0, OpenQuestions.Count - 1));
            QuestionRoundPanel.GetComponentInChildren<Text>().text = currentQuestion.Key;
        }
    }


    public void EndMPQuestionRound()
    {

        QuestionRoundPanel = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        QuestionRoundPanel.SetActive(false);

        LevelCanvasHandler.instance.SetRightQuestionText(currentMultipleChoiceQuestion.Answer, "Team " + bestTeam + " got the best score");
        ExtrasManager.instance.GiveLaserToRobot(RobotManager.instance.robots[bestTeam]);


    }


    public void EndOpenQuestionRound()
    {
        ExtrasManager.instance.ShootTheSwarm();
    }

    public void QuestionAnswered(string message, int participantID)
    {
        if (ExtrasManager.instance.isMultipleChoice)
        {
            ValidateClosedQuestion(message, participantID);
        }
        else
        {
            ValidateOpenQuestion(message,  participantID);
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
    public void ValidateOpenQuestion(string Answer, int participantID)
    {
        if (currentQuestion.Value == Answer)
        {
            EndOpenQuestionRound();
            LevelCanvasHandler.instance.SetRightQuestionText(Answer, "Player: " +  utils.instance.getTeam(participantID).ToString() + "got it right");
        }
        else
        {
            Debug.Log("Question Answerd Wrong!");
        }
    }



    private void setUIPanel()
    {
        int prevTeamStatus = 0;

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
                //   teamScoreText[i].text = Status.ToString();
                if (Status > prevTeamStatus) { bestTeam = i; }
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
