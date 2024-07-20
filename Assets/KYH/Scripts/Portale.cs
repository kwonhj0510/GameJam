using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portale : MonoBehaviour
{
    public bool IsPlayerTouched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            if(IsPlayerTouched)
            {
                Debug.Log("a");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsPlayerTouched = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsPlayerTouched = false;
    }
}
