using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endappear : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndShow()
    {

        transform.DOLocalMoveY(0, 5f).SetEase(animationCurve);
        Debug.Log("awefawef");
    }
}
