using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZERO : MonoBehaviour
{

    endappear end;
    [SerializeField] public List<GameObject> objectList;
    [SerializeField] public GameObject player;

    public float destructionDelay = 1f; // �� ������Ʈ�� ������� �ð� ����

    private void Awake()
    {
        end = GameObject.Find("End_Img").GetComponent<endappear>();
    }

    public void InvokeZeroCo()
    {
        StartCoroutine(Zero());
    }

    private IEnumerator Zero()
    {
        foreach (GameObject obj in objectList)
        {
            if (obj != null)
            {
                obj.SetActive(false);
                yield return new WaitForSeconds(destructionDelay);
            }
        }

        objectList.ForEach(x => { Destroy(x); });

        yield return new WaitForSeconds(5f);

        Destroy(player);
        end.EndShow();
    }
}
