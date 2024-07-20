using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;


    [SerializeField] private int maxHP = 10;
    [SerializeField] public int curHP;

    private void Awake()
    {
        curHP = maxHP;
    }
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if (curHP <= 0)
        {
            Destroy(gameObject); // ���� ������ ������Ʈ�� �ı��մϴ�.
            Instantiate(particle, transform.position, Quaternion.identity);
        }
    }

    
}
