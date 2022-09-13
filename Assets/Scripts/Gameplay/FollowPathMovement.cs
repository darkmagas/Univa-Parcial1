using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{

    private List<Transform> _WayPoints = new List<Transform>();
    private int _currentWayPoint = 0;
    public float speed = 5f;
    public float minDistance = 0.2f;
    public string pathName = "Path";


    // Start is called before the first frame update
    void Start()
    {
        var WaypointParent = GameObject.Find("Path");
        for (int i = 0; i < WaypointParent.transform.childCount; i++)
        {
            _WayPoints.Add(WaypointParent.transform.GetChild(i));
        }
        StartCoroutine(MoveToNextWaypoint());
    }

    private IEnumerator MoveToNextWaypoint()
    { 
    
        var distance = Vector3.Distance(transform.position,
             _WayPoints[_currentWayPoint].position);
        while (Mathf.Abs(distance) > minDistance)
        {
            transform.position = Vector3.MoveTowards( transform.position,
                _WayPoints[_currentWayPoint].position, Time.deltaTime * speed);
            distance = Vector3.Distance(transform.position,
             _WayPoints[_currentWayPoint].position);
            yield return null;
        }

        if (_currentWayPoint < _WayPoints.Count - 1)
        {
            _currentWayPoint++;
            StartCoroutine(routine: MoveToNextWaypoint());

        }

    }
}
