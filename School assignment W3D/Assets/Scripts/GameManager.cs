using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager gameManager { get; private set; }
    public GameObject player1;
    public GameObject player2;
    public GameObject winScreen;
    public TextMeshProUGUI WinScreenDeclaration;
    public bool gameOver = false;
    public GameObject pauseScreen;

    public PauseScript pauseScript;
    void Awake()
    {

        if (gameManager != null && gameManager != this)
        {

            Destroy(this);


        }
        else
        {

            gameManager = this;

        }

        Time.timeScale = 1;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            Pause();
            PauseScript.gameIsPaused = true;
        }


        if (player1.activeSelf != true)
        {
            winScreen.SetActive(true);
            WinScreenDeclaration.text = ("player 2 wins");
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (player2.activeSelf != true)
        {
            winScreen.SetActive(true);
            WinScreenDeclaration.text = ("player 1 wins");
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
        }



    }
    
    public void Pause()
    {

        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        
    }

}
