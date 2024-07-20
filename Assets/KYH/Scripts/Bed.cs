using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    TextType textType;
    // Start is called before the first frame update
    void Awake()
    {
        textType = GameObject.Find("Click").GetComponent<TextType>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textType.IsAble = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        textType.IsAble = false;
    }
}
