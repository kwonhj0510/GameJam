using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLow : MonoBehaviour
{
    AudioSource AudioSource;
    SaveAndLoad SNL;
    // Start is called before the first frame update
    void Start()
    {
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = SNL.sound.LocalBGSound;
    }
}
