using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBtn : MonoBehaviour
{
    public bool IsTouchable = false;
    public float M_speed = 6.0f;
    public MoveBtn moveBtn;
    public Setting setting;
    public bool IsShowed = false;
    // Start is called before the first frame update
    void Start()
    {
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
            moveBtn.a = 1;
            moveBtn.StartCoroutine(moveBtn.GetBack());
        }
    }
    public void ExitBtn()
    {
        if(IsTouchable)
        {
            moveBtn.a = 0;
            moveBtn.StartCoroutine(moveBtn.GetBack());
            Debug.Log("Exited");
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
