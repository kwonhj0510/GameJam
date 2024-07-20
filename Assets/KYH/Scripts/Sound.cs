using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Slider slider,slider2;
    SaveAndLoad SNL;
    // Start is called before the first frame update
    void Start()
    {
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
        slider.value = SNL.sound.LocalBGSound;
        slider2.value = SNL.sound.LocalSEFSound;
    }

    // Update is called once per frame
    void Update()
    {
        SNL.sound.LocalBGSound = slider.value;
        SNL.sound.LocalSEFSound = slider2.value;
    }
}
