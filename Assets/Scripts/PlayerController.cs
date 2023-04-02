using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform Hand;
    [SerializeField] Blinking blinking;

    int allowedPlaceUnit = 1;//You can only move 1 unity per round

    bool isInCharge = false;
    int currentRoundUnit = 0;

    public int CurrentUnit => currentUnit;
    int currentUnit = 0;//which unit player is at

    public void OnUpdateGameState()
    {
        if(GameManager.Instance.CurrentState == GameState.PlayerInCharge)
        {
            isInCharge = true;
            currentRoundUnit = 0;
        }
        else
        {
            isInCharge = false;
        }
    }

    private void Update()
    {
        if (!isInCharge)
            return;

        //Move forward
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentRoundUnit < allowedPlaceUnit)
            {
                currentRoundUnit++;
                UpdateUnit(1);
            }
        }

        //Move back
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentRoundUnit > -allowedPlaceUnit)
            {
                currentRoundUnit--;
                UpdateUnit(-1);
            }
        }

        //Go to the next game state
        if(Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.PlayerDone();
            blinking.ClickToBlink();
        }
    }

    void UpdateUnit(int delta)
    {
        currentUnit += delta;
        UpdateHand();
    }

    void UpdateHand()
    {
        float handPoszDelta = 0.08f;
        var pos = Vector3.zero;
        pos.z = handPoszDelta * currentUnit;
        Hand.localPosition = pos;
    }
}
