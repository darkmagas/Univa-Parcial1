using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovementrScript : MonoBehaviour
{
    private List<Transform> _waypoints = new List<Transform>();
    private int _currentwaypoint = 0;
    public float speed = 5f;
    public float minDistance = 0.2f;


    private void OnEnable()
    {
        _waypoints.Clear();
        _currentwaypoint = 0;
    }



    public void InitEnemy(string pathName)
    {
        var waypointParent = GameObject.Find("PathName");
        for (int i = 0; i < waypointParent.transform.childCount; i++)
        {
            _waypoints.Add(item: waypointParent.transform.GetChild(i));
        }

        StartCoroutine(MoveToNextwaypoint());
    }



    private IEnumerator MoveToNextwaypoint()
    {
        var distance = Vector3.Distance(transform.position, _waypoints[_currentwaypoint].position);

        while (Mathf.Abs(distance) > minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position,_waypoints[_currentwaypoint].position, Time.deltaTime * speed);
            distance = Vector3.Distance(transform.position, _waypoints[_currentwaypoint].position);


            yield return null;
        }


        if (_currentwaypoint < _waypoints.Count - 1)
        {
            _currentwaypoint++;
            StartCoroutine(MoveToNextwaypoint());
        }

    }
}
