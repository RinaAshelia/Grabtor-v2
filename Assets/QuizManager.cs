using System.Net.NetworkInformation;
using System.Numerics;
using System.Net.Mime;
using System.Buffers;
using System.Xml;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuizManager : MonoBehaviour
{
  public List<QuestionsAndAnswers> QnA;
  public GameObject[] options;
  public int currentQuestion;
  public TextMeshProUGUI QuestionText;
  public TextMeshProUGUI QuestionHeadline;   

  public GameObject StartScreen;
  public GameObject QuizScreen;

  private int correctAnswered;
  private int falseAnswered; 
  private int questionCounter;

  private void Start()
  {
    StartScreen.SetActive(true);
    QuizScreen.SetActive(false);
  }

  public void correct() {
    QnA.RemoveAt(currentQuestion);
    correctAnswered = correctAnswered + 1;
    generateQuestion();
  }

public void dasistfalschduhund() {
    QnA.RemoveAt(currentQuestion);
    falseAnswered = falseAnswered + 1;
    generateQuestion();
  }

  public void startQuiz(){
    UnityEngine.Debug.Log("Start the quiz");
    StartScreen.SetActive(false);
    QuizScreen.SetActive(true);

    correctAnswered = 0;
    falseAnswered = 0;
    questionCounter = 0;
    generateQuestion();
  }


  private void SetAnswers()
  {
    for (int i = 0; i < options.Length; i++)
    {
        options[i].GetComponent<AnswerScript>().isCorrect = false;
        options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

        if (QnA[currentQuestion].CorrectAnswer == i+1) {
            options[i].GetComponent<AnswerScript>().isCorrect = true;
        }
    }
  }

void generateQuestion()
  {
    if (QnA.Count < 1) {
        UnityEngine.Debug.Log("OUT OF QUESTIONS");
        finishScreen();
        return;
    }
        questionCounter = questionCounter + 1;
        currentQuestion = UnityEngine.Random.Range(0, QnA.Count);

        QuestionHeadline.text = " Question " + questionCounter;
        QuestionText.text = QnA[currentQuestion].Question;
        SetAnswers();
  }

void finishScreen() {
    for(int i = 0; i < options.Length; i++) {
        options[i].SetActive(false);
    }

    QuestionHeadline.text = "Finish, great! You answered all our questions. Did you learn something?";
    QuestionText.text = "correct: " + correctAnswered + " / false: " + falseAnswered;
  }
}
