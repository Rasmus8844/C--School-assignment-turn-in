using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;

    
    private int currentPlayerIndex;
    private bool waitingFornNextTurn;
    private float turnDelay;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
            playerOne.SetPlayerTurn(1);
            playerTwo.SetPlayerTurn(2);

        }

    }


    private void Update()
    {
        
        if (waitingFornNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingFornNextTurn = false;
                ChangeTurn();
            }
        }
    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingFornNextTurn)
        {
            
            return false;

        }

        return index == currentPlayerIndex;

    }

    public static TurnManager GetInstance()
    {

        return instance;

    }

    public void TriggerChangeTurn()
    {
        waitingFornNextTurn = true;

    }

    public void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {

            currentPlayerIndex = 2;

        }
        else if(currentPlayerIndex == 2)
        {

            currentPlayerIndex = 1;

        }

    }

}
