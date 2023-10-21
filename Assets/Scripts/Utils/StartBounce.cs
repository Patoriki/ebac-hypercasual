using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartBounce : MonoBehaviour
{
    [Header("Animation")]
    public float scaleDuration = 0.2f;
    public float scaleBounce = 1f;
    public Ease ease = Ease.OutBack;

    // Start is called before the first frame update
    void Start()
    {
        Bounce();
    }

    public void Bounce()
    {
        transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetDelay(0.5f);
    }
}
