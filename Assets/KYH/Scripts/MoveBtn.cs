using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBtn : MonoBehaviour
{
    public PlayBtn playBtn;
    public float M_speed = 6.0f;
    public Transform TargetMoveTransform,OriginalTransform;
    public int a = 0;
    SaveAndLoad SNL;
    // Start is called before the first frame update
    void Start()
    {
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
        playBtn = GameObject.Find("Click").GetComponent<PlayBtn>();
        StartCoroutine(Lerf());
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector2.MoveTowards(gameObject.transform.position, TargetMoveTransform.position, M_speed);
        // M_speed -= Time.deltaTime * 3.2f;
        // if (M_speed <= 0.5f)
        //     M_speed = 0.5f;

    }

    IEnumerator Lerf()
    {
        while (true)
        {
            transform.position = Vector2.Lerp(transform.position, TargetMoveTransform.position, M_speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, TargetMoveTransform.position) <= 0.1f)
            {
                playBtn.IsTouchable = true;
                yield break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public IEnumerator GetBack()
    {
        playBtn.IsTouchable = false;
        while (true)
        {
            transform.position = Vector2.Lerp(transform.position, OriginalTransform.position, M_speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, OriginalTransform.position)<= 0.1f)
            {
                if (a == 1)
                {
                    SceneManager.LoadScene(SNL.data.sceneName);
                }
                else if (a == 0)
                {
                    Application.Quit();
                }
                yield break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
