using System.Collections.Generic;
using Model;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private int idTheme;

    public string nameJson;

    public TMP_Text question;
    public TMP_Text answersA;
    public TMP_Text answersB;
    public TMP_Text answersC;
    public TMP_Text answersD;
    public TMP_Text InfoResponse;

    private List<Question> questionsList;
    private int idQuestion;

    private float hits;
    private float amountQuestions;
    private float average;
    private int finalGrade;

    void Start()
    {
        idTheme = PlayerPrefs.GetInt("idTheme");
        LoadQuestionsFromJson();
        idQuestion = 0;
        amountQuestions = questionsList.Count;

        DisplayQuestion();
    }

    void LoadQuestionsFromJson()
    {
        string path = Resources.Load<TextAsset>(nameJson).text;
        QuestionData questionData = JsonConvert.DeserializeObject<QuestionData>(path);
        questionsList = questionData.questions;
    }

    void DisplayQuestion()
    {
        Question currentQuestion = questionsList[idQuestion];
        question.text = currentQuestion.question;
        answersA.text = currentQuestion.answers[0];
        answersB.text = currentQuestion.answers[1];
        answersC.text = currentQuestion.answers[2];
        answersD.text = currentQuestion.answers[3];

        InfoResponse.text = "Respondendo " + (idQuestion + 1).ToString() + " de " + amountQuestions.ToString() + " perguntas.";
    }

    public void Answers(string alternative)
    {
        Question currentQuestion = questionsList[idQuestion];
        if (alternative == currentQuestion.correct)
        {
            AudioManager.Instance.PlayCorrect();
            hits += 1;
        }
        else
        {
            AudioManager.Instance.PlayWrong();
        }

        nextQuestion();
    }

    void nextQuestion()
    {
        idQuestion += 1;

        if (idQuestion < amountQuestions)
        {
            DisplayQuestion();
        }
        else
        {
            average = 10 * (hits / amountQuestions);
            finalGrade = Mathf.RoundToInt(average);

            if (finalGrade > PlayerPrefs.GetInt("finalGrade" + idTheme.ToString()))
            {
                PlayerPrefs.SetInt("finalGrade" + idTheme.ToString(), finalGrade);
                PlayerPrefs.SetInt("hits" + idTheme.ToString(), (int)hits);
            }
            PlayerPrefs.SetInt("finalGradeTemp" + idTheme.ToString(), finalGrade);
            PlayerPrefs.SetInt("hitsTemp" + idTheme.ToString(), (int)hits);
            SceneManager.LoadScene("FinalGrade");
        }
    }

    void Update()
    {

    }
}
