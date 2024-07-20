using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public class TextTypes
{
    public string[] text1;
    public int textSelect = 0;
}
public class TextType : MonoBehaviour
{
    public bool IsAble = false;
    public GameObject Box;
    public TextTypes Texts = new TextTypes();
    public TextMeshProUGUI textMeshProUGUI;
    public bool Istyping = false;
    public SaveAndLoad SNL;
    public PlayerController Player;

    private void Awake()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Box.SetActive(Istyping);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (IsAble)
            {
                if (!Istyping)
                {
                    StartCoroutine(TypeText(Texts.text1[Texts.textSelect]));
                }
            }
        }
    }

    public IEnumerator TypeText(string text)
    {
        Player.isGameStart = false;
        SNL.data.timeScale = 0;
        Istyping = true;
        Box.SetActive(Istyping);
        textMeshProUGUI.text = null;

        for(int i = 0; i < text.Length; i++)
        {
            textMeshProUGUI.text += text[i];

            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1);
       Istyping = false;
       Box.SetActive(Istyping);
        SNL.data.timeScale = 1;
        Player.isGameStart = true;
    }
}
