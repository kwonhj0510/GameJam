using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPannulIngame : MonoBehaviour
{
    public SaveAndLoad SNL;
    public bool IsAppear = false;
    public Transform OriginalTransform;
    [SerializeField] private AnimationCurve animationCurve;
    // Start is called before the first frame update
    void Start()
    {
        SNL = GetComponent<SaveAndLoad>();
    }

    // Update is called once per frame
    public void anotherMoving()
    {
        if (!IsAppear)
        {
            transform.DOLocalMoveY(0, 0.5f).SetEase(animationCurve);
            Debug.Log("awefawef");
            IsAppear = true;
        }
        else
        {
            transform.DOLocalMoveY(1068, 0.5f).SetEase(animationCurve);
            Debug.Log("awefawef2");
            IsAppear = false;
        }
    }
}
