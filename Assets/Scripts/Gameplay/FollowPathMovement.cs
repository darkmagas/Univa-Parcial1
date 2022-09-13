using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{


    private List<Transform> _wayPoints = new List<Transform>();
    private int _currentWaypoint = 0;
    public float speed = 5f;
    public float minDistance = 0.2f;
    public string pathName = "Path";

    // Start is called before the first frame update
    void Start()
    {
        var waypointParent = GameObject.Find("Path");

        for(int i = 0; i< waypointParent.transform.childCount; i++)
        {
            _wayPoints.Add(waypointParent.transform.GetChild(i));
        }


        StartCoroutine(MoveToNextWaypoint());


    }

    // Update is called once per frame
    //void Update()
    
    private IEnumerator MoveToNextWaypoint()
    {
        var distance = Vector3.Distance(transform.position, _wayPoints[_currentWaypoint].position);

        while (Mathf.Abs(distance) > minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWaypoint].position, Time.deltaTime * speed);

            distance = Vector3.Distance(transform.position, _wayPoints[_currentWaypoint].position);

            yield return null;

            

        }

        if (_currentWaypoint < _wayPoints.Count - 1)
        {
            _currentWaypoint++;
            StartCoroutine(MoveToNextWaypoint());
        }


    }
        
    
}
