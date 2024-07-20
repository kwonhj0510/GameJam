using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotate : MonoBehaviour
{
    public SaveAndLoad SNL;
    public float RotationSpeed = 1f;

    public void Awake()
    {
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
    }

    // Update is called once per frame
    void Update()
    {
        RotationSpeed += Time.deltaTime * 50 * SNL.data.timeScale;
        transform.rotation = Quaternion.Euler(0, 0,RotationSpeed);
    }
}
