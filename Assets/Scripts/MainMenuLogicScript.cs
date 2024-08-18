using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogicScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
