using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class RoundDisplay : MonoBehaviour
{
    [SerializeField] TextMeshPro timeTextMesh;

    public void OnUpdateGameState()
    {
        timeTextMesh.DOKill();

        switch (GameManager.Instance.CurrentState)
        {
            case GameState.PlayerInCharge:
                //set time blinking
                var color = Color.white;
                timeTextMesh.color = color;
                color.a = 0;
                timeTextMesh.DOColor(color, 0.3f).SetLoops(-1, LoopType.Yoyo);
                break;
            case GameState.OpponentInCharge:
                //set time stop and show as red
                timeTextMesh.color = Color.red;
                break;
            default:
                break;
        }
        UpdateTime();
    }

    void UpdateTime()
    {
        //A hacky way to do time
        var currenTime = GameManager.Instance.CurrentRound;
        timeTextMesh.text = "0:0" + currenTime;
    }
}
