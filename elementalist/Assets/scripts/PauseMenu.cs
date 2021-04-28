using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    // states that the game is not paused and the game should continue as normal
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        // checks if 'escape' key has been pressed and the gamestate is not paused
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKey(KeyCode.Joystick1Button7) && GameIsPaused == false))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {  
        // turns the menu off when the resume button is clicked 
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        // turns the menu on when the escape button 
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
