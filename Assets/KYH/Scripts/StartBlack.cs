using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBlack : MonoBehaviour
{
    public bool IsAppear = false;
    public Transform OriginalTransform;
    [SerializeField] private AnimationCurve animationCurve;
    // Start is called before the first frame update
    void Start()
    {
        EnterBlack();
    }
    public void EnterBlack()
    {
        if (!IsAppear)
        {
            OriginalTransform.DOLocalMoveX(1950, 0.5f).SetEase(animationCurve);
            IsAppear = true;
        }
        else
        {
            OriginalTransform.DOLocalMoveX(0, 0.5f).SetEase(animationCurve);
            IsAppear = false;
        }
    }
}