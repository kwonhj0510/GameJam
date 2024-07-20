using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpPortal : MonoBehaviour
{
    public SaveAndLoad SNL;
    public StartBlack StartBlack;
    void Start()
    {
        StartBlack = GameObject.Find("B_Img").GetComponent<StartBlack>();
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
            StartCoroutine(eefefe());
        }
    }
    IEnumerator eefefe()
    {
        StartBlack.EnterBlack();
        yield return new WaitForSeconds(0.5f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
