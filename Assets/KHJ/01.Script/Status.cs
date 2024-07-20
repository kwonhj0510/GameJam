using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField] private int maxHP = 100;
    [SerializeField] public int curHP;

    private void Awake()
    {
        curHP = maxHP;
    }
    
}
