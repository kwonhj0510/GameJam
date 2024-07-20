using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    TextType textType;
    bool IsTyped = false;
    // Start is called before the first frame update
    void Awake()
    {
        textType = GameObject.Find("Click").GetComponent<TextType>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!IsTyped)
            {
                WellTalk();
                IsTyped = true;
            }
        }
    }

    void WellTalk()
    {
        textType.Texts.textSelect = 1;
        Debug.Log(textType.Texts.text1[textType.Texts.textSelect]);
        StartCoroutine(textType.TypeText(textType.Texts.text1[textType.Texts.textSelect]));
    }
}
