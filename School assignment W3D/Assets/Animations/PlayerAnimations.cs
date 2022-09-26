using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] PlayerTurn playerTurn;
    [SerializeField] public Animator animator;
    public bool readyToJumpAnim;
    public int readyToJumpAnimReset = 1;
    void Update()
    {
        if (playerTurn.IsPlayerTurn())

        if (Input.GetKeyDown(KeyCode.Space) && readyToJumpAnim)
        {
            readyToJumpAnim = false;

            animator.SetTrigger("JumpTrigger");


            Invoke(nameof(ResetJump), readyToJumpAnimReset);
        }
        
    }
    private void ResetJump()
    {
        readyToJumpAnim = true;

    }
}
