using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLogicScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu, gameOverMenu, winMenu, weaponMenu, hud,
        tutorialText;
    [SerializeField] GameObject[] wavesText;
    bool paused = false;

    int wave = 0;
    [SerializeField] float[] waveDurations;
    [SerializeField] float waveTimer;
    bool waveActive;
    [SerializeField] EnemySpawnerScript spawner;

    private void Start() {
        Instantiate(tutorialText);
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
            Pause(pauseMenu);

        if(waveActive)
        {
            if(waveTimer < waveDurations[wave])
                waveTimer += Time.deltaTime;
            else
            {
                waveTimer = 0;
                spawner.SetWave(0);
                waveActive = false;
            }
        }
        else
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !paused)
                Pause((wave < 4)? weaponMenu : winMenu);
        }
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
        hud.SetActive(false);
        Debug.Log("Game paused (" + menu.name + " opened)");
    }

    public void Unpause(GameObject menu)
    {
        paused = false;
        Time.timeScale = 1;
        menu.SetActive(false);
        hud.SetActive(true);
        Debug.Log("Game unpaused (" + menu.name + " closed)");

        //Reloads the scene if you lost
        if (menu.CompareTag("GameOver"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (menu.CompareTag("WeaponSelection"))
            StartWave();
    }

    public bool isPaused()
    {
        return paused;
    }

    void StartWave()
    {
        wave++;
        waveActive = true;
        waveTimer = 0;
        spawner.SetWave(wave);
        Instantiate(wavesText[wave]);
        Debug.Log("Wave " + wave + " started");
    }

    public int GetWave()
    {
        return wave;
    }
}
