using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraManager : MonoBehaviour
{
    public PlayerTurn playerTurn1;
    public PlayerTurn playerTurn2;
    public AudioListener player1Audio;
    public AudioListener player2Audio;
    public Camera camera1;
    public Camera camera2;
    public GameObject Player1HudHealth;
    public GameObject Player2HudHealth;
    public TextMeshProUGUI timerText1;
    public TextMeshProUGUI timerText2;
    float seconds = 40.0f;

    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
        timerText1.text = seconds.ToString();
        timerText2.text = seconds.ToString();

    }

    void Update()
    {
        

        if (playerTurn1.IsPlayerTurn() && camera1 != null)
        {
            camera1.enabled = true;
            camera2.enabled = false;
            Player1HudHealth.SetActive(true);
            Player2HudHealth.SetActive(false);
            player1Audio.enabled = true;
            player2Audio.enabled = false;
        }

        if (playerTurn2.IsPlayerTurn() && camera2 != null)
        {
            camera1.enabled = false;
            camera2.enabled = true;
            Player1HudHealth.SetActive(false);
            Player2HudHealth.SetActive(true);
            player1Audio.enabled = false;
            player2Audio.enabled = true;
        }

        seconds -= Time.deltaTime;
        timerText1.text = seconds.ToString();
        timerText2.text = seconds.ToString();

        if (seconds <= 0)
        {
            TurnManager.GetInstance().TriggerChangeTurn();
            Invoke("ResetTimer", 2);
        }

        if (Input.GetMouseButtonDown(0))
        {

            Invoke("ResetTimer", 2);

        }
    }

    public void ResetTimer()
    {
        seconds = 40.0f;
    }



}
