using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    public void ExitBtn()
    {
        SceneManager.LoadScene("Intro");
    }
}

