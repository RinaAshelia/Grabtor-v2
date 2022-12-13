using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour {
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer() {
        if (isCorrect) {
            UnityEngine.Debug.Log("Correct Answer");
            quizManager.correct();
        } else {
            UnityEngine.Debug.Log("Wrong Answer");
            quizManager.dasistfalschduhund();
        }
    }
}
