using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAnimations : MonoBehaviour
{
    [SerializeField] public PlayerTurn playerTurn; 
    [SerializeField] public Animator animator;
    [SerializeField] private AudioSource cannonFire;
    void Update()
    {
        if(playerTurn.IsPlayerTurn())

        if (Input.GetKeyDown(KeyCode.Mouse0) && PauseScript.gameIsPaused != true)
        {
            cannonFire.Play();
            animator.SetTrigger("cannonTrigger");

        }
    }
}
