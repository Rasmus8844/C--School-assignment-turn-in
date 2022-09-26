using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class VictoryScreenScript : MonoBehaviour
{

    public void RestartLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

    }



}
