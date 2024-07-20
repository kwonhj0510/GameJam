using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Setting : MonoBehaviour
{
    public SaveAndLoad SNL;
    public PlayBtn playBtn;
    public bool IsAppear = false;
    public Transform OriginalTransform;
    [SerializeField] private AnimationCurve animationCurve;
    // Start is called before the first frame update
    private void Start()
    {
        SNL = GetComponent<SaveAndLoad>();
        playBtn = GameObject.Find("Click").GetComponent<PlayBtn>();
    }

    public void Moving()
    {
        if (!IsAppear)
        {
            OriginalTransform.DOLocalMoveY(0, 0.5f).SetEase(animationCurve);
            IsAppear = true;
        }
        else
        {
            OriginalTransform.DOLocalMoveY(1068, 0.5f).SetEase(animationCurve);
            IsAppear = false;
        }
    }

    public void SettingBtn()
    {
         Moving();
        playBtn.IsTouchable = true;
    }
}
