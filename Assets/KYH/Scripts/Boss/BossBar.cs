using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    public SaveAndLoad SNL;
    public GameObject boss;
    public Slider Slider;
    public float bossMaxHP = 100;
    public float bossCurHP = 100;
    // Update is called once per frame

    private void Awake()
    {
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
    }

    void Update()
    {
        bossCurHP -= Time.deltaTime * SNL.data.timeScale;
        if(bossCurHP <= 0)
        {
            Destroy(boss);
        }
        Slider.value = bossCurHP/bossMaxHP;
    }
}
