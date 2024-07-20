using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exitpannul : MonoBehaviour
{
    bool IsShow = false;
    public GameObject panul;
    // Start is called before the first frame update
    void Start()
    {
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
                Time.timeScale = 0f;
                IsShow = true;
            }
            else
            {
                panul.SetActive(false);
                Time.timeScale = 1f;
                IsShow = false;
            }
        }
    }
    public void Continue()
    {
        panul.SetActive(false);
        Time.timeScale = 1f;
        IsShow = false;
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}
