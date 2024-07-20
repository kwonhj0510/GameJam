using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exitpannul : MonoBehaviour
{
    StartBlack StartBlack;
    PlayerController controller;
    bool IsShow = false;
    public GameObject panul;
    SaveAndLoad SNL;
    // Start is called before the first frame update
    void Start()
    {
        StartBlack = GameObject.Find("B_Img").GetComponent<StartBlack>();
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
        panul.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!IsShow)
            {
                controller.isGameStart = false;
                panul.SetActive(true);
                SNL.data.timeScale = 0;
                IsShow = true;
            }
            else
            {
                controller.isGameStart = true;
                panul.SetActive(false);
                SNL.data.timeScale = 1f;
                IsShow = false;
            }
        }
    }
    public void Continue()
    {
        panul.SetActive(false);
        SNL.data.timeScale = 1f;
        IsShow = false;
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
    public void LoadCheckPoint()
    {
        StartCoroutine(eefefe());
    }
    IEnumerator eefefe()
    {
        StartBlack.EnterBlack();
        yield return new WaitForSeconds(0.5f);
        controller.isGameStart = true;
        panul.SetActive(false);
        SNL.data.timeScale = 1f;
        IsShow = false;
        SceneManager.LoadScene(SNL.data.sceneName);
        SNL.LoadData();
    }
}
