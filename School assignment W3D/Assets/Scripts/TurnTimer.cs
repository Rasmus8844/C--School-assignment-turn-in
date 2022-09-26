using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TurnTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText1;
    public TextMeshProUGUI timerText2;
    public float seconds = 30.0f;


    public void ResetTimer()
    {
        seconds = 30.0f;
    }

    void Start()
    {
        timerText1.text = seconds.ToString();
        timerText2.text = seconds.ToString();

    }


    private void Update()
    {
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






}
