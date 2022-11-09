using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints = new List<Transform>();
    public string path = "";
    public float stoppingDistance = 0.2f;
    public float speed = 5f;

    private int _currentWayPoint;
    private Vector3 _originalPosition;
    private bool _isDeath = false;

    //public

    //protected

    //internal
    // Start is called before the first frame update
    private void OnEnable()
    {
        _isDeath = false ;
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
        while (Mathf.Abs(distance) > stoppingDistance)
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
