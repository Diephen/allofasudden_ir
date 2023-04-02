using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    //-----------------------------------------------------------------------------------------------------------------------------
    public RoundDisplay RoundDisplay;
    public PlayerController PlayerController;
    public OpponentController OpponentController;

    [HideInInspector]
    public int CurrentRound = 0;
    [HideInInspector]
    public GameState CurrentState = GameState.None;

    float durPerRound = 20;
    int totalRoundCount = 5;

    //-----------------------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        Debug.Log("Game Start!");

        CurrentRound = 0;
        EnterPlayerInCharge();
    }

    void EnterPlayerInCharge()
    {
        UpdateState(GameState.PlayerInCharge);
    }

    public void PlayerDone()
    {
        //Enter opponent in charge
        UpdateState(GameState.OpponentInCharge);
    }

    public void OpponentDone()
    {
        //The round gets add up when the opponent finishes
        CurrentRound++;
        if(CurrentRound >= totalRoundCount)
        {
            //End game
            Debug.Log("Game End!");
        }else
        {
            //Enter player in charge
            EnterPlayerInCharge();
        }
    }

    void UpdateState(GameState state)
    {
        CurrentState = state;
        PlayerController.OnUpdateGameState();
        OpponentController.OnUpdateGameState();
        RoundDisplay.OnUpdateGameState();
    }
}

public enum GameState
{
    None = 0,
    PlayerInCharge = 1,
    OpponentInCharge = 2,
}