using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    [SerializeField] Animator animator;

    float ReactionDuration = 2;

    public void OnUpdateGameState()
    {
        if(GameManager.Instance.CurrentState != GameState.OpponentInCharge)
        {
            return;
        }

        //opponent reacts to player's hand's current unit
        var unit = Mathf.Clamp(GameManager.Instance.PlayerController.CurrentUnit, -2, 2);
        animator.SetInteger("currentUnit", unit);//TODO: Zi: there is a bug of the animation not playing properly that i haven't figure out yet
        StartCoroutine(WaitToEnd());
    }

    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(ReactionDuration);
        GameManager.Instance.OpponentDone();
    }
}
