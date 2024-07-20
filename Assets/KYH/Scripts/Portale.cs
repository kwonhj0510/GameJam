using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portale : MonoBehaviour
{
    public SaveAndLoad SNL;
    // Start is called before the first frame update
    void Start()
    {
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SNL.SaveData();
        }
    }
}
