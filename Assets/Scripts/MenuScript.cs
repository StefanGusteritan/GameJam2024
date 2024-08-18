using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    LevelLogicScript logicScript;
    [SerializeField] Animator animator;
 
    private void Start() {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LevelLogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            animator.SetTrigger("Exit");
    }

    public void Exit()
    {
        logicScript.Unpause(gameObject);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }
}
