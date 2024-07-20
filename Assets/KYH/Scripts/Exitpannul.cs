using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exitpannul : MonoBehaviour
{
    bool IsShow = false;
    public GameObject panul;
    SaveAndLoad SNL;
    // Start is called before the first frame update
    void Start()
    {
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
                panul.SetActive(true);
                SNL.data.timeScale = 0;
                IsShow = true;
            }
            else
            {
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
        panul.SetActive(false);
        SNL.data.timeScale = 1f;
        IsShow = false;
        SceneManager.LoadScene(SNL.data.sceneName);
        SNL.LoadData();
    }
}
