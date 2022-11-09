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
    private Vector3 _originalPosition;
    private bool _isDeath = false;

    private void OnEnable()
    {
        _isDeath = false;
        _originalPosition = transform.position;
        _wayPoints.Clear();
        _currentWayPoint = 0;
        GameManager.Instance.AddEnemy(1);
    }

    private void OnDisable()
    {
        transform.position = _originalPosition;
        GameManager.Instance.AddEnemy(-1);
    }

    public void OnDeath()
    {
        _isDeath = true;
        StopCoroutine(MoveToNextWaypoint());
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
        while (Mathf.Abs(distance) > minDistance && !_isDeath)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _wayPoints[_currentWayPoint].position, Time.deltaTime * speed);
            distance = Vector3.Distance(transform.position,
                _wayPoints[_currentWayPoint].position);
            yield return null;
        }

        if (_currentWayPoint < _wayPoints.Count - 1 && !_isDeath)
        {
            _currentWayPoint++;
            StartCoroutine(MoveToNextWaypoint());
        }
    }
}
