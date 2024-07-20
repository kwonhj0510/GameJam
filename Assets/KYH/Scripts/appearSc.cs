using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appearSc : MonoBehaviour
{
    TextType textType;
    public GameObject HiddenObject, HiddenObject2;
    // Start is called before the first frame update
    void Awake()
    {
        HiddenObject.SetActive(false);
        HiddenObject2.SetActive(false);
        textType = GameObject.Find("Click").GetComponent<TextType>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HiddenObject.SetActive(true);
            HiddenObject2.SetActive(true);
        }
    }
}
