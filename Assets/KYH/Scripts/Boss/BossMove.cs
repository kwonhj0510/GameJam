using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public SaveAndLoad SNL;
    [SerializeField] private List<Transform> waypoints = new();
    [SerializeField] private Transform playerTransform;
    private Vector3 selectedWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
        StartCoroutine(SelectWaypoint());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, selectedWaypoint, Time.deltaTime * 10 * SNL.data.timeScale);
    }

    IEnumerator SelectWaypoint()
    {
        while (true) 
        {
            var index = Random.Range(0, waypoints.Count + 1);
            if (index == waypoints.Count)
            {
                selectedWaypoint = playerTransform.position;
            }
            else
            {
                selectedWaypoint = waypoints[index].position;
            }
            yield return new WaitForSeconds(Random.Range(1,3));
        }
    }
}
