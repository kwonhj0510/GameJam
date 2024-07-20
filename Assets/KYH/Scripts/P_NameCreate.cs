using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class P_NameCreate : MonoBehaviour
{
    public InputField InputField;
    SaveAndLoad SNL;
    // Start is called before the first frame update
    void Start()
    {
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
    }

    public void TextDone()
    {
        SNL.data.PlayerName = InputField.text;
        SceneManager.LoadScene("Tutorial");
        SNL.SaveData();
    }
}
