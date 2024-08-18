using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLogicScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu, gameOverMenu;
    bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
            Pause(pauseMenu);
    }

    public void GameOver()
    {
        Pause(gameOverMenu);
    }

    void Pause(GameObject menu)
    {
        paused = true;
        Time.timeScale = 0;
        menu.SetActive(true);
        Debug.Log("Game paused (" + menu.name + " opened)");
    }

    public void Unpause(GameObject menu)
    {
        paused = false;
        Time.timeScale = 1;
        menu.SetActive(false);
        Debug.Log("Game unpaused (" + menu.name + " closed)");

        //Reloads the scene if you lost
        if (menu.CompareTag("GameOver"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool isPaused()
    {
        return paused;
    }
}
