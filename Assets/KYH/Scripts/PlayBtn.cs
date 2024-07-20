using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBtn : MonoBehaviour
{
    StartBlack StartBlack;
    public bool IsTouchable = false;
    public float M_speed = 6.0f;
    public MoveBtn moveBtn;
    public Setting setting;
    public bool IsShowed = false;
    // Start is called before the first frame update
    void Start()
    {
        StartBlack = GameObject.Find("B_Img").GetComponent<StartBlack>();
        setting = GameObject.Find("Setting_Img").GetComponent<Setting>();
        moveBtn = GameObject.Find("Btn").GetComponent<MoveBtn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Playbtn()
    {
        if(IsTouchable)
        {
            StartBlack.EnterBlack();
            moveBtn.a = 1;
            moveBtn.StartCoroutine(moveBtn.GetBack());
        }
    }
    public void ExitBtn()
    {
        if(IsTouchable)
        {
            Application.Quit();
        }
    }
    public void SettingBtn()
    {
        if (IsTouchable)
        {
            setting.Moving();
            IsTouchable = false;
        }
    }
}
