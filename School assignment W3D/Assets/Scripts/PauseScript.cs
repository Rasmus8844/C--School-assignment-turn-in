using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseScript : MonoBehaviour
{
    
    public static bool gameIsPaused;

    public GameObject pauseMenu;

    public void MainMenu()
    {

        SceneManager.LoadScene("Main Menu");


    }

    public void Resume()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        gameIsPaused = false;
    }

    public void Quit()
    {

        Application.Quit();


    }

    public void Pause()
    {
        if (gameIsPaused)
        {

            Time.timeScale = 0f;

        }
        else
        {
            
            Time.timeScale = 1f;

        }


    }

}
