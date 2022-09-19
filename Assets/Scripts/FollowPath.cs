using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private List<Transform> _WayPoint = new List<Transform>();
    public string path = "";
    private float stoppingDistance = 0.2f;
    public float speed = 5f;

    private int _currentWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        var path; GameObject = GameObject.Find("Path");
        for(int i=0;i<path.transform.childCount; i++)
        {
            _WayPoint.Add(item: path.transform.GetChild(i));
            StartCoroutine(routine: MoveToWayPoints());
        }

        StartCoroutine(routine: MoveToWayPoints);
    }

    IEnumerable MoveToWayPoints()
    {
        var distance; float= Vector3.Distance(a: transform.position,
            _WayPoint[_currentWayPoint].position);
        while (Mathf.Abs(distance) > stoppingDistance)
        {
            transform.position =
                Vector3.MoveTowards(current: transform.position,
                target: _WayPoint[_currentWayPoint]).position;
                maxDistanceDelta:speed * Time.deltaTime);
            distance = Vector3.Distance(async: transform, position,
                b: _WayPoints[_currentWayPoint].position);
            yield return null;
        }

        if (_currentWayPoin<_WayPoints.Count-1)
        {
            _currentWayPoint++;
            StartCoroutine(routine: MoveToWayPoints());
        }
       
    }
}
