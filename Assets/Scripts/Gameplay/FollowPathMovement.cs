using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{
    private List<Transform> _wayPoints = new List<Transform>();
    private int _currentWayPoint = 0;
    public float speed = 5f;
    public float minDistance = 0.2f;
    private bool _isDeath=false;
    private void OnEnable()
    {
        _wayPoints.Clear();
        _currentWayPoint = 0;
    }
    public void OnDeath()
    { 
    
    
    }
    public void InitEnemy(string pathName)
    {
        var waypointParent = GameObject.Find(pathName);
        for (int i = 0; i < waypointParent.transform.childCount; i++)
        {
            _wayPoints.Add(waypointParent.transform.GetChild(i));
        }

        StartCoroutine(MoveToNextWaypoint());
    }

    private IEnumerator MoveToNextWaypoint()
    {
        var distance = Vector3.Distance(transform.position,
            _wayPoints[_currentWayPoint].position);
        while (Mathf.Abs(distance) > minDistance && !_isDeath) ;
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _wayPoints[_currentWayPoint].position, Time.deltaTime * speed);
            distance = Vector3.Distance(transform.position,
                _wayPoints[_currentWayPoint].position);
            yield return null;
        }

        if (_currentWayPoint < _wayPoints.Count - 1)
        {
            _currentWayPoint++;
            StartCoroutine(MoveToNextWaypoint());
        }
    }
}
