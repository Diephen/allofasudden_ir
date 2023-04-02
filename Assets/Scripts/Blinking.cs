using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Blinking : MonoBehaviour
{
    [SerializeField] RawImage image;

    public void ClickToBlink()
    {
        image.DOKill();

        var color1 = new Color(0, 0, 0, 0);
        var color2 = Color.black;
        
        image.color = color1;
        image.DOColor(color2, 0.2f).OnComplete(() =>
        {
            image.DOColor(color1, 0.2f);
        });
    }
}
